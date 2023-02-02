using System;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
//using Android.Content.Res;
using NUnit.Framework;
using Xamarin.UITest;

namespace AppCenter.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public async Task APITestAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync("http://localhost:8080/api/testresponse").ConfigureAwait(false))
                    {
                        var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var result = (string.IsNullOrEmpty(responseString) ? "<Empty>" : responseString);
                        Console.WriteLine("APITestAsync :" + result);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("APITestAsync exception:" + ex);
            }
        }

        [Test]
        public void AppLaunches()
        {
            app.Repl();
            var xtclang = Environment.GetEnvironmentVariable("XTC_LANG");
            Console.WriteLine($"XTC_LANG={xtclang}");
            
           // var lang = Resources.System.Configuration.Locale;
           // Console.WriteLine(lang);

            Console.WriteLine(System.Globalization.RegionInfo.CurrentRegion);
            RegionInfo myRI1 = new RegionInfo(RegionInfo.CurrentRegion.ToString());
            Console.WriteLine("   Name:                         {0}", myRI1.Name);
            Console.WriteLine("   DisplayName:                  {0}", myRI1.DisplayName);
            Console.WriteLine("   EnglishName:                  {0}", myRI1.EnglishName);
            Console.WriteLine("   IsMetric:                     {0}", myRI1.IsMetric);
            Console.WriteLine("   ThreeLetterISORegionName:     {0}", myRI1.ThreeLetterISORegionName);
            Console.WriteLine("   ThreeLetterWindowsRegionName: {0}", myRI1.ThreeLetterWindowsRegionName);
            Console.WriteLine("   TwoLetterISORegionName:       {0}", myRI1.TwoLetterISORegionName);
            Console.WriteLine("   CurrencySymbol:               {0}", myRI1.CurrencySymbol);
            Console.WriteLine("   ISOCurrencySymbol:            {0}", myRI1.ISOCurrencySymbol);
            Console.WriteLine();

            // Compares the RegionInfo above with another RegionInfo created using CultureInfo.
            RegionInfo myRI2 = new RegionInfo(new CultureInfo("nb-NO", false).LCID);
            if (myRI1.Equals(myRI2))
                Console.WriteLine("The two RegionInfo instances are equal.");
            else
                Console.WriteLine("The two RegionInfo instances are NOT equal.");
            // ((System.Drawing.Color)Xamarin.Forms.Color.Gray).ToArgb();
            Assert.IsTrue(true);
        }
        [Test]
        public void SampleXamarinUI()
        {
            //app.Tap(c => c.Marked("NoResourceEntry-4")); //android
            app.Tap(c => c.Property("text").Contains("IO"));
            app.Screenshot("Cicked on IO");
            app.Tap(c => c.Property("text").Contains("sample error"));
            app.Screenshot("Cicked on Div");
            app.Tap(c => c.Property("text").Contains("FNF"));
            app.Screenshot("Cicked on FNF");
            app.Tap(c => c.Property("text").Contains("color"));
            app.Screenshot("Cicked on ycolor");
            app.Tap(c => c.Property("text").Contains("Yellow"));
            app.Screenshot("Cicked on Yellow");
            app.Tap(c => c.Property("text").Contains("color"));
            app.Screenshot("Cicked on bcolor");
            app.Tap(c => c.Property("text").Contains("Blue"));
            app.Screenshot("Cicked on Blue");
            app.Tap(c => c.Property("text").Contains("color"));
            app.Screenshot("Cicked on rcolor");
            app.Tap(c => c.Property("text").Contains("Red"));
            app.Screenshot("Cicked on Red");
            app.Tap(c => c.Property("text").Contains("sample event"));
            app.Screenshot("Cicked on t1");
            app.Tap(c => c.Property("text").EndsWith("Time"));
            app.Screenshot("Cicked on Time");
            app.Tap(c => c.Property("text").Contains("sample event"));
            app.Screenshot("Cicked on t2");
            app.Tap(c => c.Property("text").EndsWith("Time2"));
            app.Screenshot("Cicked on Time2");
        }
        //[Test]
        //public void TestDivErrors()
        //{
        //    //app.Tap(c => c.Marked("NoResourceEntry-5"));
        //    app.Tap(c => c.Property("text").Contains("sample error"));
        //    app.Screenshot("Cicked on Div");
        //}
        //[Test]
        //public void TestFNFErrors()
        //{
        //   // app.Tap(c => c.Marked("NoResourceEntry-6"));
        //    app.Tap(c => c.Property("text").Contains("FNF"));
        //    app.Screenshot("Cicked on FNF");
        //}
        //[Test]
        //public void TestYEvent()
        //{
        //    //app.Tap(c => c.Marked("NoResourceEntry-9"));
        //    app.Tap(c => c.Property("text").Contains("color"));
        //    app.Screenshot("Cicked on ycolor");
        //    app.Tap(c => c.Property("text").Contains("Yellow"));
        //    app.Screenshot("Cicked on Yellow");
        //}
        //[Test]
        //public void TestBEvent()
        //{
        //    //app.Tap(c => c.Marked("NoResourceEntry-9"));
        //    app.Tap(c => c.Property("text").Contains("color"));
        //    app.Screenshot("Cicked on bcolor");
        //    app.Tap(c => c.Property("text").Contains("Blue"));
        //    app.Screenshot("Cicked on Blue");
        //}
        //[Test]
        //public void TestREvent()
        //{
        //    //app.Tap(c => c.Marked("NoResourceEntry-9"));
        //    app.Tap(c => c.Property("text").Contains("color"));
        //    app.Screenshot("Cicked on rcolor");
        //    app.Tap(c => c.Property("text").Contains("Red"));
        //    app.Screenshot("Cicked on Red");
        //}

        //[Test]
        //public void TestT1Event()
        //{
        //    //app.Tap(c => c.Marked("NoResourceEntry-9"));
        //    app.Tap(c => c.Property("text").Contains("sample event"));
        //    app.Screenshot("Cicked on t1");
        //    app.Tap(c => c.Property("text").EndsWith("Time"));
        //    app.Screenshot("Cicked on Time");
        //}

        //[Test]
        //public void TestT2Event()
        //{
        //    //app.Tap(c => c.Marked("NoResourceEntry-9"));
        //    app.Tap(c => c.Property("text").Contains("sample event"));
        //    app.Screenshot("Cicked on t2");
        //    app.Tap(c => c.Property("text").EndsWith("Time2"));
        //    app.Screenshot("Cicked on Time2");
        //}

        //[Test]
        //public void TestCrash()
        //{
        //    // app.Repl();

        //    //app.Tap(c => c.Marked("NoResourceEntry-5"));
        //    //app.Tap(c => c.Marked("NoResourceEntry-6"));
        //    //app.Tap(c => c.Marked("NoResourceEntry-8"));
        //    //app.Tap(c => c.Marked("NoResourceEntry-9"));
        //    //app.Tap(c => c.Marked("text1").Property("text").Contains("Yellow"));
        //    //app.Tap(c => c.Marked("NoResourceEntry-9"));
        //    //app.Tap(c => c.Marked("text1").Property("text").Contains("Blue"));
        //    //app.Tap(c => c.Marked("NoResourceEntry-9"));
        //    //app.Tap(c => c.Marked("text1").Property("text").Contains("Red"));
        //    //app.Tap(c => c.Marked("NoResourceEntry-7"));
        //    //app.Tap(c => c.Marked("button1"));
        //    app.Tap(c => c.Property("text").Contains("crash"));
        //    app.Tap(c => c.Property("text").Contains("Crash"));
        //    //Thread.Sleep(8000);
        //}
    }
}
