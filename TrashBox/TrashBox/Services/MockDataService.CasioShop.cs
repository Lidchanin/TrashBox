using System;
using System.Collections.Generic;
using System.Linq;
using TrashBox.Enums;
using TrashBox.Helpers;
using TrashBox.Models;

namespace TrashBox.Services
{
    public partial class MockDataService
    {
        private enum MainAdvantages
        {
            WaterResistant100M,
            WaterResistant200M,
            MagneticResistant,
            ShockResistant,
            LEDBacklight,
            ELBacklight,
            ELBacklightWithAfterglow,
            LEDLight,
            Stopwatch,
            SecondStopwatch100Th,
            SecondStopwatch1000Th,
            LEDLightWithAfterglow,
            LEDBacklightWithAfterglow,
            WorldTime,
            BluetoothConnectivity,
            SolarPowered,
            ResinBand,
            DailyAlarm4SnoozeAlarm1,
            StepTracker,
            MultiBand6AtomicTimekeeping,
            Sensors5
        }

        public IList<WatchInfo> GetBabyWatches()
        {
            return new List<WatchInfo>
            {
                new WatchInfo
                {
                    Series = CasioWatchSeries.BabyG,
                    Name = "BA110-1A",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.ShockResistant, MainAdvantages.LEDBacklight,
                        MainAdvantages.WaterResistant100M),
                    Description =
                        @"Casio Baby-G is growing up with a new collection of timepieces inspired by its analog and digitally-dynamite “big brother,” the XL GA110 G-Shock. The BA110 model(s) feature a lightweight, glossy resin band in two fashionable hues of black and white casting a spotlight on the large watch face brushed in striking gold and rose gold metallic. The BA110 is equipped with a layered 3D metallic face, along with gear motif hands, which nod to the sophisticated styling cues of industrial design. Women can bring class to work with the white/rose gold, white/silver, silver/silver and clock out to take on the night with the black/gold. Black resin band analog and digital watch with metallic gold face.",
                    Cost = 120,
                    ImagePath = Constants.EmbeddedImages.CasioBabyGBA1101A
                },
                new WatchInfo
                {
                    Series = CasioWatchSeries.BabyG,
                    Name = "BA111-1A",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.WaterResistant100M,
                        MainAdvantages.ShockResistant, MainAdvantages.LEDLight),
                    Description =
                        "This new street fashion neon color is the latest addition to the popular BA110 Series. The dial of this model is basic black, accented with pink. Layered construction creates a multi-dimensional design that is accented by the use of various types of materials and the sizes of these watches are designed to fit the feminine wrist, while maintaining plenty of eye-catching appeal.",
                    Cost = 120,
                    ImagePath = Constants.EmbeddedImages.CasioBabyGBA1111A
                },
                new WatchInfo
                {
                    Series = CasioWatchSeries.BabyG,
                    Name = "BA130-1A3",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.WaterResistant100M,
                        MainAdvantages.ShockResistant, MainAdvantages.LEDLightWithAfterglow),
                    Description =
                        @"From BABY-G, the casual watch for active women, come gorgeous new models for the holiday season.
The base model is the popular big case, mannish BA-130, and brilliantly colored metal face parts create designs that are reminiscent of Christmas tree ornaments. Glittering blue, pink, and yellow faces combine with the elegant matte black finish of the case and band for designs that are casual, yet adult and romantic.
These new models add a touch of cool glittering brilliance to winter street styles.",
                    Cost = 120,
                    ImagePath = Constants.EmbeddedImages.CasioBabyGBA1301A3
                },
                new WatchInfo
                {
                    Series = CasioWatchSeries.BabyG,
                    Name = "BGD560TG-9",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.WaterResistant200M,
                        MainAdvantages.ShockResistant, MainAdvantages.ELBacklight),
                    Description =
                        @"From BABY-G, the casual watch for active women, comes a collection of new models in the same colors as the models created for the TEAM G-SHOCK of top athletes. The yellow with white accent coloring of this newest BGD560 model creates a design in the image of a thunderbolt. The face and EL LCD image also have a lightning and the band is imprinted with the words “ABSOLUTE TOUGHNESS,” which is part of the G-SHOCK basic concept of constantly meeting new challenges.",
                    Cost = 89,
                    ImagePath = Constants.EmbeddedImages.CasioBabyGBGD560TG9
                },
                new WatchInfo
                {
                    Series = CasioWatchSeries.BabyG,
                    Name = "BGA110-1B2",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.WaterResistant100M,
                        MainAdvantages.ShockResistant, MainAdvantages.LEDLightWithAfterglow),
                    Description =
                        @"Adding to the already popular BGA110 series, Baby-G introduces three new colorways. Known for its unique faux link band, chaton style protectors and stainless steel bezel, the BGA110 is an attractive accessory as much as it is a functional timepiece. Three digital windows and large hour markers provide easy-to-read timekeeping and style. Black resin band analog and digital watch with black face.",
                    Cost = 99,
                    ImagePath = Constants.EmbeddedImages.CasioBabyGBGA1101B2
                },
                new WatchInfo
                {
                    Series = CasioWatchSeries.BabyG,
                    Name = "BG169R-7E",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.WaterResistant200M,
                        MainAdvantages.ShockResistant, MainAdvantages.WorldTime),
                    Description =
                        @"The face of this 200-meter water resistant BABY-G model features eye-catching vivid color. An ion-plated metal ring combines with a face protector to create a face that is dynamic, yet classic BABY-G.
Both the case and band is done in a popular semi-transparent clear color. The wire face protectors on the case allow for worry-free wear at the beach, at the pool, or in other high-activity areas.
Features include day counter, world time, tele-memo, and other functions that come in handy throughout the day.",
                    Cost = 79,
                    DiscountPercent = 20,
                    ImagePath = Constants.EmbeddedImages.CasioBabyGBG169R7E
                },
                new WatchInfo
                {
                    Series = CasioWatchSeries.BabyG,
                    Name = "BGD560S-6",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.WaterResistant200M,
                        MainAdvantages.ShockResistant, MainAdvantages.LEDBacklightWithAfterglow),
                    Description =
                        @"Trendy semi-transparent bands and cases create designs that are perfect for just about any summer outdoor scene. Available in 2 colors: purple or black. Base model is the standard popular square face BGD560.",
                    Cost = 79,
                    ImagePath = Constants.EmbeddedImages.CasioBabyGBGD560S6,
                    IsNew = true
                }
            };
        }

        public IList<WatchInfo> GetFemaleWatches()
        {
            return new List<WatchInfo>
            {
                new WatchInfo
                {
                    Series = CasioWatchSeries.GShockWomen,
                    Name = "GMAB800-9A",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.WaterResistant200M,
                        MainAdvantages.Stopwatch, MainAdvantages.BluetoothConnectivity),
                    Description =
                        @"Introducing the latest additions to the G-SHOCK S series lineup of sports watches that are designed and engineered to make daily training more fun and effective. The size of the new GMAB800 is approximately 3 mm smaller than the case of the popular G-SHOCK GBA800, which makes it the perfect choice for those with smaller wrists. This model can also be combined with the GBA800 as a his-and-hers pair. The watch can Bluetooth® link with a smartphone, which makes sports activities even more fun, while the G-SHOCK Connected phone app provides access to a number of functions that support workouts. Daily health and fitness support functions include a 3-axis accelerometer that keeps track of step counts, a timer that lets you create up to 20 combinations of five timers each, memory for up to 200 lap records, and more.",
                    Cost = 120,
                    ImagePath = Constants.EmbeddedImages.CasioWomenGMAB8009A
                },
                new WatchInfo
                {
                    Series = CasioWatchSeries.GShockWomen,
                    Name = "MSGS500G-5A",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.SolarPowered,
                        MainAdvantages.WaterResistant100M, MainAdvantages.ResinBand),
                    Description =
                        @"The thin case, flat face, and bar hour markers of this model result in a simple and stylish look. The MSGS500G series combine an elegant metal case and resin bands. They are just the thing for today's modern adult. Three hands and a day indicator combine with a solar power system for uninterrupted timekeeping throughout the day. These G-MS models are designed to fit in just about anywhere and to coordinate well with a wide range of fashions.",
                    Cost = 220,
                    ImagePath = Constants.EmbeddedImages.CasioWomenMSGS500G5A,
                    IsNew = true
                },
                new WatchInfo
                {
                    Series = CasioWatchSeries.GShockWomen,
                    Name = "GMAS120MF-7A2",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.WaterResistant200M,
                        MainAdvantages.SecondStopwatch100Th, MainAdvantages.DailyAlarm4SnoozeAlarm1),
                    Description =
                        @"Part of the Metallic Face Series with analog and digital dial displays, metallic accents on the face and matte band in pastel shades. Equipped with standard G-SHOCK technology including 200M water resistance, shock resistance, magnetic resistance, auto LED Light with Afterglow, world time (48 cities + UTC), 5 daily alarms and 1 snooze, 1/1000th second stopwatch, countdown timer, and 12/24 hour formats - all in a 45.9mm case.",
                    Cost = 130,
                    ImagePath = Constants.EmbeddedImages.CasioWomenGMAS120MF7A2
                },
                new WatchInfo
                {
                    Series = CasioWatchSeries.GShockWomen,
                    Name = "GMDB800SC-1B",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.WaterResistant200M,
                        MainAdvantages.ResinBand, MainAdvantages.BluetoothConnectivity),
                    Description =
                        @"Introducing new compact G-SHOCK models that are great choices for women who prefer bulky G-SHOCK styling.
These models add a new selection of colors to the G-SHOCK Connected lineup of sports watches that make daily training more fun and effective. The size of the GMD-B800 case is approximately 3 mm smaller than the case of the popular G-SHOCK GBD-800, which makes it the perfect choice for those with smaller wrists and those who prefer a more compact watch. These new models come in neon colors that go well with today's trendy sportswear. A back protector protects against impact, while block coloring and new materials create designs with plenty of visual impact.
The watch can use Bluetooth® to link with the G-SHOCK Connected phone app to provide access to a number of functions that support workouts.
Daily health and fitness support functions include a 3-axis accelerometer that keeps track of step counts, a timer that lets you create up to 20 combinations of five timers each, memory for up to 200 lap records, and more. G-SHOCK Connected also makes it possible to maintain step count logs with five exercise intensity levels, calculate the calories you burn, specify a daily step target, create timer combinations and send them to the watch, store stopwatch measurement data, view data, and more. All of this combines to help you plan and record your workouts, making them more effective and enjoyable.
Other features include app-based auto time setting correction for more efficient timekeeping, and an Auto Double LED Light that facilitates workouts in areas where lighting is dim.",
                    Cost = 99,
                    DiscountPercent = 50,
                    ImagePath = Constants.EmbeddedImages.CasioWomenGMDB800SC1B
                },
                new WatchInfo
                {
                    Series = CasioWatchSeries.GShockWomen,
                    Name = "GMAS120SR-7A",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.MagneticResistant,
                        MainAdvantages.WaterResistant200M, MainAdvantages.ShockResistant),
                    Description =
                        @"Introducing new compact G-SHOCK models that are great choices for women who prefer G-SHOCK styling. Transparent styles were introduced and became very popular back in the ’90s, making them an essential part of G-SHOCK history.
The faces of these models have a rose-gold metallic finish, and their solid designs make them perfect wrist-worn accents for everything from mode fashions, to street and casual fashions. Base model for this lineup is the popular GA120.",
                    Cost = 140,
                    ImagePath = Constants.EmbeddedImages.CasioWomenGMAS120SR7A
                },
                new WatchInfo
                {
                    Series = CasioWatchSeries.GShockWomen,
                    Name = "GMS5600PG-4",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.WaterResistant200M,
                        MainAdvantages.ShockResistant, MainAdvantages.ELBacklightWithAfterglow),
                    Description =
                        @"Introducing the new compact G-SHOCK models that are great choice for women who prefer the active G-SHOCK styling. This iconic square design of the 5600 Series is now equipped with a metal-covered bezel. All the shock resistance of the GM5600 in a smaller size for a lightweight and comfortable fit to the wrist. These designs blends elegance and casualness in ways that make them go great with street fashions. The case and bezel have mirror finishes that enhance the texture of the metal. This lineup provides a choice of four colors, including two pink gold models, a champagne gold model and, a silver model.",
                    Cost = 180,
                    DiscountPercent = 25,
                    ImagePath = Constants.EmbeddedImages.CasioWomenGMS5600PG4,
                    IsNew = true
                },
                new WatchInfo
                {
                    Series = CasioWatchSeries.GShockWomen,
                    Name = "GMDB800SU-4",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.WaterResistant200M,
                        MainAdvantages.StepTracker, MainAdvantages.BluetoothConnectivity),
                    Description =
                        @"Introducing the latest additions to the G-SQUAD lineup of sports watches that make daily training more fun and effective. The size of the GMDB800 case is approximately 3 mm smaller than the case of the popular G-SHOCK GBA800, which makes it the perfect choice for those with smaller wrists and those who prefer a more compact watch.
The three colors of this lineup have been specially selected to create models that look great for normal daily wear as well as in sports scenes. The colors are sure to remain in fashion for a long time to come.",
                    Cost = 99,
                    ImagePath = Constants.EmbeddedImages.CasioWomenGMDB800SU4,
                    IsNew = true
                }
            };
        }

        public IList<WatchInfo> GetMaleWatches()
        {
            return new List<WatchInfo>
            {
                new WatchInfo
                {
                    Series = CasioWatchSeries.GShock,
                    Name = "GMWB5000TCF-2",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.SolarPowered, MainAdvantages.ShockResistant,
                        MainAdvantages.MultiBand6AtomicTimekeeping),
                    Description =
                        @"This is new variations on the full-metal GMWB5000 that incorporate titanium material into their square-face design, which inherits plenty of the DNA of the original G-SHOCK DW5000C.
The case, band, bezel, and back cover of this new model is made of lightweight, easy-on-the-wrist titanium. Titanium is notorious as being a material that is difficult to work with, and its application in this model represents a significant achievement. The surface of the metal is finished with a diamond like carbon (DLC) coating that protects it against scratching and other damage.
The GMWB5000TCF model with titanium case, bezel, band, and back, which is laser engraved with a distinctive camouflage pattern. After a DLC coating is applied to the case and band, the gradations of the camouflage pattern are created by using dot patterns of three different sizes: small, medium, and large.
This new full-metal GMWB5000 Series watch maintains the original G-SHOCK concept while improving overall timekeeping quality.",
                    Cost = 1700,
                    ImagePath = Constants.EmbeddedImages.CasioGShockGMWB5000TCF2
                },
                new WatchInfo
                {
                    Series = CasioWatchSeries.GShock,
                    Name = "GBDH1000-7A9",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.SolarPowered,
                        MainAdvantages.BluetoothConnectivity, MainAdvantages.Sensors5),
                    Description =
                        @"These G-SHOCK G-MOVE GBDH1000 Series models pack heart rate measurement and GPS capabilities into a choice of black or white designs made of semitransparent resin. The result is powerfully vibrant timepieces that look great no matter where they are worn.
Useful workout functions include an optical sensor for heart rate measurement, along with bearing, altitude/barometric pressure, and temperature sensors, and an accelerometer for step counting. These five sensors help to keep you in close touch with your current activity in real-time. The ability to receive GPS signals lets you access location information when you need it. When used in combination with the stopwatch, you can keep track of running information like distance, speed, pace, and more. The watch uses your heart rate and speed data to calculate a VO2max value, which is an indicator of your cardio-pulmonary capacity. This measurement is useful when trying to increase stamina for running and other activities. A phone app is available to help you configure watch settings and manage your training data.
You can monitor your current fitness level and training progress, and even automatically create a training plan based on targets specified by you. VO2max calculation and other data analysis capabilities use a library by FIRSTBEAT, a renowned sports science company. Algorithms of improved accuracy support a higher level of training. The surface form of the back covers of these models reduces interference with the back of the hand, while a soft urethane band provides a better fit to the wrist. Bi-color molded buttons are designed for ease of use, while a high-definition MIP LCD makes display information more legible. Both USB and solar charging are supported, and solar charging can be used to power daily operations (except for pulse monitoring and GPS). Both of these models provide renowned G-SHOCK toughness along with new outdoor functions.",
                    Cost = 399,
                    ImagePath = Constants.EmbeddedImages.CasioGShockGBDH10007A9,
                    IsNew = true
                },
                new WatchInfo
                {
                    Series = CasioWatchSeries.GShock,
                    Name = "GA700DC-1A",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.WaterResistant200M,
                        MainAdvantages.ShockResistant, MainAdvantages.LEDLight),
                    Description =
                        @"These new G-SHOCK models feature digital camouflage patterns on metallic faces that result in subdued designs. Base models are the original square face GWB5600 digital, GA140 and GA700 analog-digital timepieces. The basic black coloring of these models is offset by vivid yellow accents for a cool look.",
                    Cost = 110,
                    ImagePath = Constants.EmbeddedImages.CasioGShockGA700DC1A
                },
                new WatchInfo
                {
                    Series = CasioWatchSeries.GShock,
                    Name = "GBD100-1A7",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.WaterResistant200M,
                        MainAdvantages.BluetoothConnectivity, MainAdvantages.ShockResistant),
                    Description =
                        @"These are the latest additions to the G-SHOCK MOVE lineup of sports watches, now with Bluetooth® capabilities that allow continuous connection with a smartphone.
These watches can link with the GPS of a smartphone for quicker calibration of distance measurements, enabling more accurate running distance measurements, even during use without a phone connection.
Distance measurements used in combination with the stopwatch let you keep track of your running pace, and also enable use of an Auto Lap feature that automatically keeps track of times over a specific distance.
Other standard features include a step tracker (pedometer), interval timers (up to 20 sets of five timers each), lap time measurement (up to 140 records for up to 100 runs), and calories burned measurement, all of which provide plenty of support for your daily training. Also, new phone apps are now available to help you configure watch settings more easily and manage your workouts. In addition to Life Log and Activity History apps, you can automatically create a training plan based on targets specified by you.
The displays of these watches use a high-definition MIP LCD, while Super Illuminator face illumination keeps face information easy to read, even in the dark. The soft urethane band material provides improved comfort, while a large number of band holes let you adjust the fit to your particular wrist. The watch maintains a constant Bluetooth® connection with your phone to support auto time adjustment, phone notifications, step tracking, and other functions throughout the day. Even so, battery life is approximately two years between replacements.
From daily health management to improved running endurance, these new G-SHOCK MOVE models provide tools that support a wide range of fitness needs.",
                    Cost = 150,
                    ImagePath = Constants.EmbeddedImages.CasioGShockGBD1001A7
                },
                new WatchInfo
                {
                    Series = CasioWatchSeries.GShock,
                    Name = "GM110-1A",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.MagneticResistant,
                        MainAdvantages.WaterResistant200M, MainAdvantages.ShockResistant),
                    Description =
                        @"The stainless steel bezel of this analog-digital GM110 Series model have been forged, cut and polished to give it its distinctive design.
The GM110 model has a silver bezel and dial for a metallic look.",
                    Cost = 200,
                    DiscountPercent = 30,
                    ImagePath = Constants.EmbeddedImages.CasioGShockGM1101A
                },
                new WatchInfo
                {
                    Series = CasioWatchSeries.GShock,
                    Name = "GA700-7A",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.MagneticResistant,
                        MainAdvantages.ShockResistant, MainAdvantages.SecondStopwatch1000Th),
                    Description =
                        @"The ever popular GA-700 comes in new colors. These models use original resin molding technology that makes it possible to form analog hands and multi-dimensional dial in a choice of two new colors: blue resin band with black face or white band with black face. These colors go well with trainers, parkas and other typical street fashion.",
                    Cost = 99,
                    ImagePath = Constants.EmbeddedImages.CasioGShockGA7007A
                },
                new WatchInfo
                {
                    Series = CasioWatchSeries.GShock,
                    Name = "GSTB300S-1A",
                    MainAdvantages = GetMainAdvantagesByEnum(MainAdvantages.SolarPowered,
                        MainAdvantages.WaterResistant200M, MainAdvantages.BluetoothConnectivity),
                    Description =
                        @"Introducing the new rugged style of G-STEEL models that feature Carbon Core Guard structures. These new models adopt tough G-SHOCK styling with a disk indicator at 6 o’clock that shows the current mode and charge level, and a front button that completes the overall rugged look. The disk, a round graphic digital display between 1 and 2 o'clock, and a digital display as 12 o'clock add to both functionality and looks. The GSTB300S model comes with a resin band.",
                    Cost = 330,
                    ImagePath = Constants.EmbeddedImages.CasioGShockGSTB300S1A
                }
            };
        }

        public IList<WatchInfo> GetWatches() =>
            GetBabyWatches().Concat(GetFemaleWatches()).Concat(GetMaleWatches()).ToList();

        public IList<WatchInfo> GetNewWatches() =>
            GetBabyWatches().Concat(GetFemaleWatches()).Concat(GetMaleWatches()).Where(w => w.IsNew).ToList();

        public IList<WatchInfo> GetDiscountWatches() =>
            GetBabyWatches().Concat(GetFemaleWatches()).Concat(GetMaleWatches()).Where(w => w.DiscountPercent > 0)
                .ToList();

        #region Support Methods

        private static IList<string> GetMainAdvantagesByEnum(params MainAdvantages[] mainAdvantages)
        {
            var advantages = new List<string>();

            foreach (var mainAdvantage in mainAdvantages)
            {
                switch (mainAdvantage)
                {
                    case MainAdvantages.WaterResistant100M:
                    {
                        advantages.Add("100M Water Resistant");

                        break;
                    }
                    case MainAdvantages.ShockResistant:
                    {
                        advantages.Add("Shock Resistant");

                        break;
                    }
                    case MainAdvantages.LEDBacklight:
                    {
                        advantages.Add("LED Backlight");

                        break;
                    }
                    case MainAdvantages.LEDLight:
                    {
                        advantages.Add("LED Light");

                        break;
                    }
                    case MainAdvantages.SecondStopwatch100Th:
                    {
                        advantages.Add("1/100th Second Stopwatch");

                        break;
                    }
                    case MainAdvantages.SecondStopwatch1000Th:
                    {
                        advantages.Add("1/1000 Second Stopwatch");

                        break;
                    }
                    case MainAdvantages.LEDLightWithAfterglow:
                    {
                        advantages.Add("LED Light with Afterglow");

                        break;
                    }
                    case MainAdvantages.WaterResistant200M:
                    {
                        advantages.Add("200M Water Resistant");

                        break;
                    }
                    case MainAdvantages.ELBacklight:
                    {
                        advantages.Add("Electro-luminescent Backlight");

                        break;
                    }
                    case MainAdvantages.WorldTime:
                    {
                        advantages.Add("World Time");

                        break;
                    }
                    case MainAdvantages.LEDBacklightWithAfterglow:
                    {
                        advantages.Add("LED Backlight with Afterglow");

                        break;
                    }
                    case MainAdvantages.BluetoothConnectivity:
                    {
                        advantages.Add("Bluetooth Connectivity");

                        break;
                    }
                    case MainAdvantages.Stopwatch:
                    {
                        advantages.Add("Stopwatch");

                        break;
                    }
                    case MainAdvantages.SolarPowered:
                    {
                        advantages.Add("Solar Powered");

                        break;
                    }
                    case MainAdvantages.ResinBand:
                    {
                        advantages.Add("Resin Band");

                        break;
                    }
                    case MainAdvantages.DailyAlarm4SnoozeAlarm1:
                    {
                        advantages.Add("4 Daily Alarm and One Snooze Alarm");

                        break;
                    }
                    case MainAdvantages.MagneticResistant:
                    {
                        advantages.Add("Magnetic Resistant");

                        break;
                    }
                    case MainAdvantages.ELBacklightWithAfterglow:
                    {
                        advantages.Add("Electro-luminescent Backlight With Afterglow");

                        break;
                    }
                    case MainAdvantages.StepTracker:
                    {
                        advantages.Add("Step Tracker");

                        break;
                    }
                    case MainAdvantages.MultiBand6AtomicTimekeeping:
                    {
                        advantages.Add("Multi-Band 6 Atomic Timekeeping");

                        break;
                    }
                    case MainAdvantages.Sensors5:
                    {
                        advantages.Add("5-Sensors");

                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return advantages;
        }

        #endregion Support Methods
    }
}