﻿using Android.App;
using Android.Widget;
using Android.OS;

namespace blankApp1
{
    [Activity(Label = "blankApp1", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button mainButton1= FindViewById<Button>(Resource.Id.mainbutton1);

        }
    }
}

