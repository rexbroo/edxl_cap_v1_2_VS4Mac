using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using edxl_cap_v1_2.Models;
using edxl_cap_v1_2.Models.ContentViewModels;
using static edxl_cap_v1_2.Models.ContentViewModels.AlertViewModel;

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
                Sender="w-nws.webmaster@noaa.gov",Sent=DateTime.Parse("2017-01-22 22:31:08.000"),
                Status=Status.Actual,MsgType=MsgType.Alert,Source="nws",Scope=Scope.Public,Restriction="NULL",
                Addresses="NULL",Code="NULL",Note="Alert for CAZ107; CAZ108 (California) Issued by the National Weather Service",
                References="NULL",Incidents="NULL",DataCategory_Id=1},
            new Alert {AlertIndex=2,Alert_Identifier="NOAA-NWS-ALERTS-CA125A9F5E174C.WinterWeatherAdvisory.125AA39AAE60CA.REVWSWREV.58c9bead01ca6732bc88705059f76f46",
                Sender="w-nws.webmaster@noaa.gov",Sent=DateTime.Parse("2018-04-30T03:03:00-07:00"),
                Status=Status.Actual,MsgType=MsgType.Alert,Source="nws", Scope=Scope.Public,Restriction="NULL",
                Addresses="NULL", Code="NULL", Note="Alert for Mono (California) Issued by the National Weather Service",
                References="NULL",Incidents="NULL",DataCategory_Id=1 },
            new Alert {AlertIndex=3,Alert_Identifier="NOAA-NWS-ALERTS-AK125AA3AA1EB8.FloodAdvisory.125AA3B95FCCAK.AFCFLSAFC.026e2b11e582dbb6bd863dfa37b89739",
                Sender="w-nws.webmaster@noaa.gov",Sent=DateTime.Parse("2018-05-02T11:18:00-08:00"),
                Status=Status.Actual,MsgType=MsgType.Alert,Source="nws",Scope=Scope.Public, Restriction="NULL",
                Addresses="NULL",Code="NULL",Note="Alert for Lower Kuskokwim Valley (Alaska) Issued by the National Weather Service",
                References="NULL",Incidents="NULL",DataCategory_Id=1}
            };

            foreach (Alert a in alerts)
            {
                context.Alert.Add(a);
            }
            context.SaveChanges();

            var infos = new Info[]
            {
            new Info{InfoIndex=1,Category=EdxlCapMessageCategory.Met,Language="en",Event="Winter Storm Warning",ResponseType=ResponseType.Shelter,
                Urgency=Urgency.Expected,Severity=Severity.Moderate,Certainty=Certainty.Likely,Audience="NULL",EventCode="SAME,WSW",
                Effective=DateTime.Parse("2017-01-21 22:31:08.000"),Onset=DateTime.Parse("2017-01-21 22:31:08.000"),
                Expires=DateTime.Parse("2017-01-22 12:00:00.000"),SenderName="NWS Eureka (Northwest California Coast)",
                Headline="Winter Storm Warning issued January 21 at 10:31PM PST until January 22 at 12:00PM PST by NWS Eureka",
                Description="SHOWER COVERAGE WILL CONTINUE DIMINISH THROUGH THE REMAINDER OF THE AFTERNOON." +
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
                Web="NULL",Contact="NULL",Parameter="WMOHHEADER",DataCategory_Id=2},
            new Info{InfoIndex=2,Category=EdxlCapMessageCategory.Met, Event="Winter Weather Advisory",ResponseType=ResponseType.Shelter,
                Urgency=Urgency.Expected,Severity=Severity.Minor,Certainty=Certainty.Likely,Audience="NULL",EventCode="SAME",
                Effective=DateTime.Parse("2018-04-30T20:00:00-07:00"),Expires=DateTime.Parse("2018-05-01T11:00:00-07:00"),
                SenderName="NWS Eureka (Northwest California Coast)",Headline="Winter Weather Advisory issued April 30 at 3:03AM PDT until May 01 at 11:00AM PDT by NWS Reno",
                Description="...WINTER WEATHER ADVISORY IN EFFECT FROM 8 PM THIS EVENING TO 11 AM PDT TUESDAY ABOVE 7000 FEET... " +
                "* WHAT...Snow expected.Total snow accumulations of 2 to 4 inches, with " +
                "localized amounts up to 6 inches,are expected above 7000 feet." +
                "* WHERE...Mono County south of Bridgeport." +
                "* WHEN...From 8 PM this evening to 11 AM PDT Tuesday." +
                "* ADDITIONAL DETAILS...Plan on slippery road conditions. Be prepared for reduced visibilities at times.",
                Instruction="Be sure to allow extra time to reach your destination. Leave extra space between vehicles since it takes " +
                "longer to stop on slick roadways.Check for the latest road conditions by calling 5 1 1 or visiting the CALTRANS website.",
                Web="NULL",Contact="NULL",Parameter="WMOHHEADER, UGC CAZ073", DataCategory_Id = 2 },
            new Info{InfoIndex=3,Category=EdxlCapMessageCategory.Met,Event="Flood Advisory", ResponseType = ResponseType.Shelter,
                Urgency=Urgency.Expected,Severity=Severity.Minor,Certainty=Certainty.Likely,Audience="NULL",EventCode="SAME",
                Effective=DateTime.Parse("2018-05-02T11:18:00-08:00"),Expires=DateTime.Parse("2018-05-02T11:18:00-08:00"),SenderName="NWS Anchorage (Southern Alaska - Anchorage)",
                Headline="Flood Advisory issued May 02 at 11:18AM AKDT  by NWS Anchorage",
                Description="The National Weather Service in Anchorage has issued a" +
                "* Flood Advisory for...An Ice Jam in...Aniak along the Kuskokwim River " +
                "* Until 1115 AM AKDT Thursday * Ice on the Kuskokwim River at Aniak started moving Monday evening. " +
                "Starting Tuesday morning, water levels at Aniak began rising steadily and the ice has stopped moving." +
                "Some minor flooding of low lying roads is being reported at Aniak.Additional ice runs " +
                "are moving down river toward Aniak.Flooding will continue to occur in Aniak and additional water levels increases are " +
                "likely until the Kuskokwim River ice goes out in the vicinity of Aniak.",
                Instruction = "Stay away or be swept away. River banks and culverts can become unstable and unsafe. " +
                "A Flood Advisory means river or stream flows are elevated, or ponding of water in urban or other areas is occurring or is imminent.",
                Web="NULL",Contact="NULL",Parameter="WMOHHEADER, UGC AKZ152, VTEC / O.NEW.PAFC.FA.Y.0003.180502T1918Z - 180503T1915Z // 00000.N.IJ.000000T0000Z.000000T0000Z.000000T0000Z.OO /",DataCategory_Id=2}
            };

            foreach (Info i in infos)
            {
                context.Info.Add(i);
            }
            context.SaveChanges();

            var areas = new Area[]
            {
            new Area{AreaIndex=1,AreaDesc="CAZ107; CAZ108",Polygon="39.99, -122.90 39.99, -123.54 40.80, -123.56 40.92, -123.60 40.92, -123.49 41.05, -123.41 41.09, -123.47 41.17, -123.40 41.13, -123.29 40.99, -122.94 41.08, -122.74 40.57, -123.95 41.33, -122.53 41.10, -122.46 40.70, -122.74 40.57, -122.71 40.36, -123.02 39.99, -122.90",
                Circle="NULL",Geocode ="FIPS6, UGC CAZ107, UGC CAZ108",Altitude="NULL",
                Ceiling="NULL",DataCategory_Id=3},
            new Area {AreaIndex=2,AreaDesc="Mono",Polygon="NULL",
                Circle="NULL",Geocode="FIPS6 006051, UGC, CAZ073",
                Altitude="NULL",Ceiling="NULL", DataCategory_Id = 3 },
            new Area{AreaIndex=3,AreaDesc="Lower Kuskokwim Valley",Polygon = "61.53,-159.4 61.5,-159.81 61.6,-159.81 61.62,-159.4 61.53,-159.4",
                Circle="NULL",Geocode="FIPS6 002050, UGC AKZ152",Altitude = "NULL",
                Ceiling="NULL",DataCategory_Id=3}
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
                Info_Alert_Identifier="NOAA-NWS-ALERTS-CA1258388FSECFC.WinterStormWarning.125838f803C0CA.EKAWSWEKA.d2e18d2b81b08f7bcd9e6fadde0ff6ddb",
                DataCategory_Id=4},
            new Resource{ResourceIndex=2,ResourceDesc="NULL",MimeType="NULL",
                Size=0,Uri="NULL",DerefUri="NULL",Digest="NULL",
                Info_Alert_Identifier="NNOAA-NWS-ALERTS-CA125A9F5E174C.WinterWeatherAdvisory.125AA39AAE60CA.REVWSWREV.58c9bead01ca6732bc88705059f76f46",
                DataCategory_Id=4 },
            new Resource{ResourceIndex=3,ResourceDesc="NULL",MimeType="NULL",
                Size=0, Uri="NULL",DerefUri="NULL",Digest="NULL",
                Info_Alert_Identifier="NOAA-NWS-ALERTS-AK125AA3AA1EB8.FloodAdvisory.125AA3B95FCCAK.AFCFLSAFC.026e2b11e582dbb6bd863dfa37b89739",
                DataCategory_Id=4 }
            };

            foreach (Resource r in resources)
            {
                context.Resource.Add(r);
            }
            context.SaveChanges();

            var edxlcapmessages = new EdxlCapMessage[]
            {
            new EdxlCapMessage{AlertIndex=1,SelectedAlertIndex=0,Alert_Identifier=
                "NOAA-NWS-ALERTS-CA125838fsecfc.WinterStormWarning.125838f803c0CA.EKAWSWEKA.d2e18d2b81b08f7bcd9e6fadde0ff6db",
                Sender="w-nws.webmaster@noaa.gov",Sent=DateTime.Parse("2017-01-22 22:31:08.0"),
                EdxlCapMessageStatus=Status.Actual,EdxlCapMessageMsgType=MsgType.Alert,Source="nws",
                EdxlCapMessageScope=Scope.Public,Restriction="NULL",Addresses="NULL",
                Code="NULL",Note="Alert for CAZ107; CAZ108 (California) Issued by the National Weather Service",
                References="NULL",Incidents="NULL",InfoIndex=1,Language="en",EdxlCapMessageCategory=EdxlCapMessageCategory.Met,Event="Winter Storm Warning",
                EdxlCapMessageResponseType =ResponseType.Shelter,EdxlCapMessageUrgency =Urgency.Expected,EdxlCapMessageSeverity=Severity.Moderate,
                EdxlCapMessageCertainty =Certainty.Likely,Audience="NULL",EventCode="SAME,WSW", Effective=DateTime.Parse("2017-01-21 22:31:08.000"),
                Onset =DateTime.Parse("2017-01-21 22:31:08.000"),Expires =DateTime.Parse("2017-01-22 12:00:00.000"),SenderName ="NWS Eureka (Northwest California Coast)",
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
                Web="NULL",Contact="NULL",Parameter="WMOHHEADER",AreaIndex=1,AreaDesc="CAZ107; CAZ108",Polygon="39.99, -122.90 39.99, -123.54 40.80, " +
                "-123.56 40.92, -123.60 40.92, -123.49 41.05, -123.41 41.09, -123.47 41.17, -123.40 41.13, -123.29 40.99, -122.94 41.08, -122.74 40.57, " +
                "-123.95 41.33, -122.53 41.10, -122.46 40.70, -122.74 40.57, -122.71 40.36, -123.02 39.99, -122.90",
                Circle="NULL",Geocode="FIPS6, UGC CAZ107, UGC CAZ108",Altitude="NULL",Ceiling="NULL",ResourceIndex=1,
                ResourceDesc="NULL",MimeType="NULL",Size=0,Uri="NULL",DerefUri="NULL",Digest="NULL"},
            new EdxlCapMessage{AlertIndex=2,SelectedAlertIndex=0,Alert_Identifier=
                "NOAA-NWS-ALERTS-CA125A9F5E174C.WinterWeatherAdvisory.125AA39AAE60CA.REVWSWREV.58c9bead01ca6732bc88705059f76f46",
                Sender="w-nws.webmaster@noaa.gov",Sent=DateTime.Parse("2018-04-30T03:03:00-07:00"),EdxlCapMessageStatus=Status.Actual,
                EdxlCapMessageMsgType=MsgType.Alert,Source="nws",EdxlCapMessageScope=Scope.Public,
                Restriction="NULL",References="NULL",Incidents="NULL",InfoIndex = 2,EdxlCapMessageCategory=EdxlCapMessageCategory.Met,Event="Winter Weather Advisory",
                EdxlCapMessageResponseType=ResponseType.Shelter,EdxlCapMessageUrgency=Urgency.Expected,EdxlCapMessageSeverity= Severity.Minor,
                EdxlCapMessageCertainty = Certainty.Likely,Audience="NULL",EventCode="SAME",Effective=DateTime.Parse("2018-04-30T20:00:00-07:00"),
                Expires=DateTime.Parse("2018-05-01T11:00:00-07:00"),SenderName="NWS Eureka (Northwest California Coast)",
                Headline="Winter Weather Advisory issued April 30 at 3:03AM PDT until May 01 at 11:00AM PDT by NWS Reno",
                Description="...WINTER WEATHER ADVISORY IN EFFECT FROM 8 PM THIS EVENING TO 11 AM PDT TUESDAY ABOVE 7000 FEET... " +
                "* WHAT...Snow expected.Total snow accumulations of 2 to 4 inches, with " +
                "localized amounts up to 6 inches,are expected above 7000 feet." +
                "* WHERE...Mono County south of Bridgeport." +
                "* WHEN...From 8 PM this evening to 11 AM PDT Tuesday." +
                "* ADDITIONAL DETAILS...Plan on slippery road conditions. Be prepared for reduced visibilities at times.",
                Instruction="Be sure to allow extra time to reach your destination. Leave extra space between vehicles since it takes " +
                "longer to stop on slick roadways.Check for the latest road conditions by calling 5 1 1 or visiting the CALTRANS website.",
                Web="NULL",Contact="NULL",Parameter="WMOHHEADER, UGC CAZ073",AreaIndex=2,AreaDesc="Mono",Polygon="NULL",
                Circle="NULL",Geocode="FIPS6 006051, UGC, CAZ073",Altitude="NULL",Ceiling="NULL",ResourceIndex=2,
                ResourceDesc ="NULL",MimeType="NULL",Size=0, Uri="NULL",DerefUri="NULL",Digest="NULL"},
            new EdxlCapMessage{AlertIndex=3,SelectedAlertIndex=0,Alert_Identifier=
                "NOAA-NWS-ALERTS-AK125AA3AA1EB8.FloodAdvisory.125AA3B95FCCAK.AFCFLSAFC.026e2b11e582dbb6bd863dfa37b89739",
                Sender="w-nws.webmaster@noaa.gov",Sent=DateTime.Parse("2018-05-02T11:18:00-08:00"),
                EdxlCapMessageStatus=Status.Actual,EdxlCapMessageMsgType=MsgType.Alert,Source="nws",
                EdxlCapMessageScope=Scope.Public,Restriction="NULL",Addresses="NULL",Code="NULL",
                Note ="Alert for Lower Kuskokwim Valley (Alaska) Issued by the National Weather Service",
                References="NULL",Incidents="NULL",InfoIndex=3,Language="en",EdxlCapMessageCategory=EdxlCapMessageCategory.Met,
                Event="Flood Advisory",EdxlCapMessageResponseType=ResponseType.Shelter, EdxlCapMessageUrgency=Urgency.Expected,
                EdxlCapMessageSeverity=Severity.Minor,EdxlCapMessageCertainty=Certainty.Likely,Audience="NULL",EventCode="SAME",
                Effective=DateTime.Parse("2018-05-02T11:18:00-08:00"),Expires=DateTime.Parse("2018-05-02T11:18:00-08:00"),
                SenderName="NWS Anchorage (Southern Alaska - Anchorage)",Headline="Flood Advisory issued May 02 at 11:18AM AKDT by NWS Anchorage",
                Description="The National Weather Service in Anchorage has issued a" +
                "* Flood Advisory for...An Ice Jam in...Aniak along the Kuskokwim River " +
                "* Until 1115 AM AKDT Thursday * Ice on the Kuskokwim River at Aniak started moving Monday evening. " +
                "Starting Tuesday morning, water levels at Aniak began rising steadily and the ice has stopped moving." +
                "Some minor flooding of low lying roads is being reported at Aniak.Additional ice runs " +
                "are moving down river toward Aniak.Flooding will continue to occur in Aniak and additional water levels increases are " +
                "likely until the Kuskokwim River ice goes out in the vicinity of Aniak.",
                Instruction="Stay away or be swept away. River banks and culverts can become unstable and unsafe. " +
                "A Flood Advisory means river or stream flows are elevated, or ponding of water in urban or other areas is occurring or is imminent.",
                Web ="NULL",Contact="NULL",Parameter="WMOHHEADER, UGC AKZ152, VTEC / O.NEW.PAFC.FA.Y.0003.180502T1918Z - 180503T1915Z // 00000.N.IJ.000000T0000Z.000000T0000Z.000000T0000Z.OO /",
                AreaIndex =3,AreaDesc="Lower Kuskokwim Valley",Polygon="61.53,-159.4 61.5,-159.81 61.6,-159.81 61.62,-159.4 61.53,-159.4",
                Circle ="NULL",Geocode="FIPS6 002050, UGC AKZ152",Altitude="NULL",
                Ceiling="NULL",ResourceIndex=3,ResourceDesc="NULL",MimeType="NULL",Size =0,Uri="NULL",DerefUri="NULL",Digest="NULL"}
            };

            foreach (EdxlCapMessage c in edxlcapmessages)
            {
                context.EdxlCapMessage.Add(c);
            }
            context.SaveChanges();
        }
    }
}
