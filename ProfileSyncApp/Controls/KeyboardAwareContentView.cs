using System.Diagnostics;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Platform = Microsoft.Maui.ApplicationModel.Platform;
#if IOS
using Foundation;
using Microsoft.Maui.Controls.PlatformConfiguration;
using UIKit;
#endif

namespace ProfileSyncApp.Controls;

// workaround, adapted from: https://github.com/dotnet/maui/issues/10662#issuecomment-1386680526

public class KeyboardAwareContentView : ContentView
{
#if IOS
        private NSObject _keyboardHeightChangeObserver;
        private NSObject _keyboardHideObserver;
        private NSObject _keyboardShowObserver;

        public KeyboardAwareContentView()
        {
            RegisterForKeyboardNotifications();
        }

        ~KeyboardAwareContentView()
        {
            UnregisterForKeyboardNotifications();
        }

        private bool _isShowCompleted;
        private bool _isHideCompleted;

        private void SetHeight(UIKeyboardEventArgs args)
        {
            nfloat top;
            nfloat bottom;
            
            try
            {
                var window = UIApplication.SharedApplication.Delegate.GetWindow();
                top = window.SafeAreaInsets.Top;
                bottom = window.SafeAreaInsets.Bottom;
            }
            catch
            {
                top = 0;
                bottom = 0;
            }

            var result = (NSValue)args.Notification.UserInfo!.ObjectForKey(new NSString(UIKeyboard.FrameEndUserInfoKey));

            var keyboardRect = result.CGRectValue;

            try
            {
                var viewController = Platform.GetCurrentUIViewController();

                if (viewController?.View != null)
                {
                    // https://stackoverflow.com/questions/15402281/convert-uikeyboardframeenduserinfokey-to-view-or-window-coordinates#answer-16615391
                    var windowRect = viewController.View.ConvertRectFromView(result.CGRectValue, viewController.View.Window);
                    keyboardRect = viewController.View.ConvertRectFromView(windowRect, null);
                }
            }
            catch
            {
                // ignored
            }

            ClearValue(HeightRequestProperty);
            ClearValue(VerticalOptionsProperty);
            
            var usingSafeArea = ((ContentPage)Parent).On<iOS>().UsingSafeArea();

            var outerHeight = Shell.Current == null 
                ? Height + bottom + (usingSafeArea ? top : 0)
                : Shell.Current.Height;
            
            var heightOffset = outerHeight - Height - (usingSafeArea ? top : 0);

            HeightRequest = Height - keyboardRect.Height + heightOffset;
            VerticalOptions = LayoutOptions.Start;
        }

        private void OnKeyboardHeightChanged(object sender, UIKeyboardEventArgs args)
        {
            if (_isShowCompleted && !_isHideCompleted)
            {
                try
                {
                    SetHeight(args);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"KeyboardAwareContentView.OnKeyboardHeightChanged: {ex.Message} {ex.StackTrace}");
                }
            }
        }

        private void OnKeyboardHide(object sender, UIKeyboardEventArgs args)
        {
            _isHideCompleted = true;
            _isShowCompleted = false;

            if (IsSet(HeightRequestProperty))
            {
                ClearValue(HeightRequestProperty);
                ClearValue(VerticalOptionsProperty);
            }
        }

        private void OnKeyboardShow(object sender, UIKeyboardEventArgs args)
        {
            if (_isShowCompleted)
                return;
                
            try
            {
                SetHeight(args);
                _isHideCompleted = false;
                _isShowCompleted = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"KeyboardAwareContentView.OnKeyboardShow: {ex.Message} {ex.StackTrace}");
            }
        }

        private void RegisterForKeyboardNotifications()
        {
            _keyboardShowObserver ??= UIKeyboard.Notifications.ObserveWillShow(OnKeyboardShow);
            _keyboardHeightChangeObserver ??= UIKeyboard.Notifications.ObserveWillChangeFrame(OnKeyboardHeightChanged);
            _keyboardHideObserver ??= UIKeyboard.Notifications.ObserveWillHide(OnKeyboardHide);
        }

        private void UnregisterForKeyboardNotifications()
        {
            if (_keyboardHeightChangeObserver != null)
            {
                _keyboardHeightChangeObserver.Dispose();
                _keyboardHeightChangeObserver = null;
            }

            if (_keyboardHideObserver != null)
            {
                _keyboardHideObserver.Dispose();
                _keyboardHideObserver = null;
            }

            if (_keyboardShowObserver != null)
            {
                _keyboardShowObserver.Dispose();
                _keyboardShowObserver = null;
            }
        }
#endif
}