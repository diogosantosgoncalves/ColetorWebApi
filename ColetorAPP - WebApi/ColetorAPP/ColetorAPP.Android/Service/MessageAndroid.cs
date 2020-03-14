﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ColetorAPP.Droid.Service;
using ColetorAPP.Services;


[assembly: Xamarin.Forms.Dependency(typeof(MessageAndroid))]
namespace ColetorAPP.Droid.Service
{

    class MessageAndroid: IMessage

    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }
        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}