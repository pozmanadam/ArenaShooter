/**
 * Copyright (c) 2014-present, Facebook, Inc. All rights reserved.
 *
 * You are hereby granted a non-exclusive, worldwide, royalty-free license to use,
 * copy, modify, and distribute this software in source code or binary form for use
 * in connection with the web services and APIs provided by Facebook.
 *
 * As with any software that integrates with the Facebook platform, your use of
 * this software is subject to the Facebook Developer Principles and Policies
 * [http://developers.facebook.com/policy/]. This copyright notice shall be
 * included in all copies or substantial portions of the software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

namespace Facebook.Unity.Example
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    internal sealed class MainMenuInGame : MenuBase
    {
        PlayerStats playerStats;
        private Texture2D profilePic;
        void Start(){
            playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
            FB.API("/me/picture", HttpMethod.GET, this.ProfilePhotoCallback);
        }
        private void ProfilePhotoCallback(IGraphResult result)
        {
            if (string.IsNullOrEmpty(result.Error) && result.Texture != null)
            {
                this.profilePic = result.Texture;
            }

            this.HandleResult(result);
        }

        protected override bool ShowBackButton()
        {
            return false;
        }

        protected override void GetGui()
        {
            GUILayout.BeginVertical();

            bool enabled = GUI.enabled;

            GUILayout.BeginHorizontal();


            GUI.enabled = FB.IsLoggedIn;
            if (this.Button("Get publish_actions"))
            {
                this.CallFBLoginForPublish();
                this.Status = "Login (for publish_actions) called";
            }

            // Fix GUILayout margin issues
            GUILayout.Label(GUIContent.none, GUILayout.MinWidth(ConsoleBase.MarginFix));
            GUILayout.EndHorizontal();

            if (this.profilePic != null)
            {
                GUILayout.Box(this.profilePic);
                GUILayout.Label("highscore: "+playerStats.highestKillStreak);
            }

            GUILayout.BeginHorizontal();

            // Fix GUILayout margin issues
            GUILayout.Label(GUIContent.none, GUILayout.MinWidth(ConsoleBase.MarginFix));
            GUILayout.EndHorizontal();


            GUI.enabled = enabled && FB.IsInitialized;
            if (this.Button("Share Screenshot"))
            {
                //this.SwitchMenu(typeof(DialogShare));
                enabled = false;
                this.StartCoroutine(this.TakeScreenshot());
            }

            if (this.Button("Share - Link"))
            {
                FB.GetAppLink(ShareLinkCallback);
                
            }
            void ShareLinkCallback(IAppLinkResult res){
                FB.ShareLink(new Uri(res.Url), callback: this.HandleResult);
            }


            if (this.Button("App Requests"))
            {
                FB.AppRequest("Please play", callback: this.HandleResult);
            }


            if (this.Button("Start New Game"))
            {
                //this.SwitchMenu(typeof(AppLinks));
                UnityEngine.SceneManagement.SceneManager.LoadScene("asd");
            }

            GUILayout.EndVertical();

            GUI.enabled = enabled;
        }


        private void CallFBLogin()
        {
            FB.LogInWithReadPermissions(new List<string>() { "public_profile", "email", "user_friends","publish_actions","user_photos" }, this.HandleResult);
        }

        private void CallFBLoginForPublish()
        {
            // It is generally good behavior to split asking for read and publish
            // permissions rather than ask for them all at once.
            //
            // In your own game, consider postponing this call until the moment
            // you actually need it.
            FB.LogInWithPublishPermissions(new List<string>() { "publish_actions","user_photos" }, this.HandleResult);
        }

        private void CallFBLogout()
        {
            FB.LogOut();
        }

        private void OnInitComplete()
        {
            this.Status = "Success - Check log for details";
            this.LastResponse = "Success Response: OnInitComplete Called\n";
            string logMessage = string.Format(
                "OnInitCompleteCalled IsLoggedIn='{0}' IsInitialized='{1}'",
                FB.IsLoggedIn,
                FB.IsInitialized);
            LogView.AddLog(logMessage);
            if (AccessToken.CurrentAccessToken != null)
            {
                LogView.AddLog(AccessToken.CurrentAccessToken.ToString());
            }
        }

        private void OnHideUnity(bool isGameShown)
        {
            this.Status = "Success - Check log for details";
            this.LastResponse = string.Format("Success Response: OnHideUnity Called {0}\n", isGameShown);
            LogView.AddLog("Is game shown: " + isGameShown);
        }
        void Callback(IResult res){
            Debug.Log(res);
        }
        private System.Collections.IEnumerator TakeScreenshot()
        {
            yield return new WaitForEndOfFrame();

            var width = Screen.width;
            var height = Screen.height;
            var tex = new Texture2D(width, height, TextureFormat.RGB24, false);

            // Read screen contents into the texture
            tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            tex.Apply();
            enabled = true;
            byte[] screenshot = tex.EncodeToPNG();

            var wwwForm = new WWWForm();
            wwwForm.AddBinaryData("image", screenshot, "InteractiveConsole.png");
            wwwForm.AddField("message", "herp derp.  I did a thing!  Did I do this right?");
            FB.API("me/photos", HttpMethod.POST, this.HandleResult, wwwForm);
        }
    }
}
