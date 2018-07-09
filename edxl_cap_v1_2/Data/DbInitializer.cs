using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using edxl_cap_v1_2.Models;
using edxl_cap_v1_2.Models;

namespace edxl_cap_v1_2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any alerts.
            if (context.Alert.Any())
            {
                return;   // DB has been seeded
            }

            var alerts = new Alert[]
            {
            new Alert{AlertIndex=1,Alert_Identifier="NOAA-NWS-ALERTS-CA125838fsecfc.WinterStormWarning.125838f803c0CA.EKAWSWEKA.d2e18d2b81b08f7bcd9e6fadde0ff6db",
                Sender = "w-nws.webmaster@noaa.gov",Sent=DateTime.Parse("2017-01-22 22:31:08.000"),
                Status=Status.Actual,MsgType=MsgType.Alert,Source="nws",Scope=Scope.Public,Restriction="NULL",
                Addresses="NULL",Code="NULL",Note="Alert for CAZ107; CAZ108 (California) Issued by the National Weather Service",
                References="NULL",Incidents="NULL",DataCategory_Id=1},
            };
            foreach (Alert a in alerts)
            {
                context.Alert.Add(a);
            }
            context.SaveChanges();

            var infos = new Info[]
            {
            new Info{InfoIndex=1,Category=Category.Met,Event="Winter Storm Warning",ResponseType=ResponseType.Shelter,
                Urgency=Urgency.Expected,Severity=Severity.Moderate,Certainty=Certainty.Likely,Audience="NULL",EventCode="SAME,WSW",
                Effective=DateTime.Parse("2017-01-21 22:31:08.000"),Onset=DateTime.Parse("2017-01-21 22:31:08.000"),
                Expires =DateTime.Parse("2017-01-22 12:00:00.000"),SenderName ="NWS Eureka (Northwest California Coast)",
                Headline ="Winter Storm Warning issued January 21 at 10:31PM PST until January 22 at 12:00PM PST by NWS Eureka",
                Description ="SHOWER COVERAGE WILL CONTINUE DIMINISH THROUGH THE REMAINDER OF THE AFTERNOON." +
                "..BUT BURSTS OF LIGHT SNOW CAN BE EXPECTED AT ELEVATIONS AT OR ABOVE 3500 FEET WITH LIGHT " +
                "ACCUMULATIONS POSSIBLE... HEAVY SNOW WILL RETURN TO ELEVATIONS OF 3000 OR HIGHER OVERNIGHT " +
                "SATURDAY THROUGH SUNDAY MORNING. SNOW SHOWERS WILL CONTINUE PERIODICALLY THROUGH MONDAY..." +
                "WINTER STORM WARNING REMAINS IN EFFECT UNTIL NOON PST SUNDAY ABOVE 2500 FEET ... SNOW ACCUMULATIONS... " +
                "1 TO 4 NCHES BETWEEN 2500 AND 3000 FEET 4 TO 8 INCHES BETWEEN 3000 AND 4000 FEET, 8 TO 12 INCHES ABOVE 4000 FEET " +
                "...WITH LOCALLY HIGHER AMOUNT POSSIBLE. LOCATIONS IMPACTED...TRINITY CENTER...PEANUT...HETTENSHAW...RUTH" +
                "...AND ELEVATED AREAS SURROUNDING WEAVERVILLE AND ... HAYFORK. HIGHWAYS IMPACTED...HIGHWAYS 36 AND3 WITH HIGH CERTAINTY. " +
                "LIGHTER ACCUMULATIONS POSSIBLE AT BUCKHORN AND OREGON MOUNTAIN SUMMITS OF HIGHWAY 299. FOR A DETAILED VIEW OF THE HAZARD AREA " +
                "... VISIT HTTP://WWW.WEATHER.GOV/EUREKA/HAZARDS",Instruction="A WINTER STORM WARNING MEANS THERE IS HIGH CONFIDENCE " +
                "THAT SIGNIFICANT SNOW, SLEET...OR ICE ACCUMULATIONS WILL IMPACT TRAVEL. CONTINUE TO MONITOR THE LATEST FORECASTS",
                Web ="NULL",Contact="NULL",Parameter="WMOHHEADER",DataCategory_Id=2},
            };
            foreach (Info i in infos)
            {
                context.Info.Add(i);
            }
            context.SaveChanges();

            var areas = new Area[]
            {
            new Area{AreaIndex=1,AreaDesc="CAZ107; CAZ108",Polygon="39.99, -122.90 39.99, -123.54 40.80, -123.56 40.92, -123.60 40.92, -123.49 41.05, -123.41 41.09, -123.47 41.17, -123.40 41.13, -123.29 40.99, -122.94 41.08, -122.74 40.57, -123.95 41.33, -122.53 41.10, -122.46 40.70, -122.74 40.57, -122.71 40.36, -123.02 39.99, -122.90",
                Circle ="NULL",Geocode ="FIPS6, , UGC, CAZ107, UGC, CAZ108",Altitude="NULL",
                Ceiling="NULL",DataCategory_Id=3},
            };
            foreach (Area e in areas)
            {
                context.Area.Add(e);
            }
            context.SaveChanges();

            var resources = new Resource[]
            {
            new Resource{ResourceIndex=1,ResourceDesc="NULL",MimeType="NULL",
                Size =0,Uri="NULL",DerefUri="NULL",Digest="NULL",
                Info_Alert_Identifier ="NOAA-NWS-ALERTS-CA1258388FSECFC.WinterStormWarning.125838f803C0CA.EKAWSWEKA.d2e18d2b81b08f7bcd9e6fadde0ff6ddb",
                DataCategory_Id=4},
            };
            foreach (Resource e in resources)
            {
                context.Resource.Add(e);
            }
            context.SaveChanges();
        }
    }
}
