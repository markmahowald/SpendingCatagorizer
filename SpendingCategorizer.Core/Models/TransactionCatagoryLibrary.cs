using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingCategorizer.Core.Models
{
    public class TransactionCatagoryLibrary
    {
         public Dictionary<string, string[]> Categories = new Dictionary<string, string[]>
        {

            {"Sara Business", new[] {"DEPOSIT ACH MEND AND BEND", "TIFFANY BUCKNAM", "DEPOSIT ACH VENMO ", "DEPOSIT BY CHECK MDC MDC HOLD", "YOGA CENTER OF DENVER", "NAYAX", "SAMAMKAYA ", "AKASHA ", "SARA LUCHIN", "SARA MAHOWALD", "LIVING YOGA", "ZOOM.US", "VENMO CASHOUT"}},
            {"Charity", new[] {  "SPECIAL OLYMPICS", "Wikimedia", "ZAK FOSTER QUILTS", "PATREON", "ROCKY MTN PBS", "PARTNERS IN HEALTH", "HEALTHIER COLORADO", "CURIOSITYSTREAM", "MAXIMUM FUN"}},
            {"Fun Money", new[] { "MINT  SERIF", "IRON FOOD HAL", "ROOT DOWN", "THE BUG THEATRE", "TOTAL WINE AND MORE", "SNARFS", "CORNER SLICE", "COMET CHICKEN", "QUEEN CITY", "WENDY'S", "SQ *HAPPY CONES", "BUC-EE'S", "BRIDGEWATER GRILL", "MOTOMAKI", "VITAL ROOT", "BREWERY TAPROOM", "METROPOLIS COFFEE", "EINSTEINBROS",  "SQ *MINT & SERIF", "SONDER COFFEEBAR", "ILLEGAL PETE", "DAIRY QUEEN ", "BOBA", "CAFE OLE", "GRUBHUB.COM", "LEGACY PIE ", "LIQUOR", ".NOODLES.COM", "TIFFINS INDIA", "JOYRIDE BREWING", "EINSTEIN BROS ", "SONIC DRIVE", "DisneyPLUS"," EINSTEINBROS", "PANDA EXPRESS", "Grandmas House", "THE BARDO ", "KAFFE LANDSKAP", "7-ELEVEN", "GOOD TIMES", "LEVITT PAVILION ","KNOTTED ROO", "BRAD'S PIT BBQ", "YAK AND YETI", "Mono GoGo", "WEE TEA ", "TST* LOGAN HOUSE COFFEE", "THE ORIENTAL THEATER", "WM Max LLC", "Xbox", "ALAMO ", "YUMMYS DONUT HOUSE", "3dprinter.com", "AMK GATES CAFE", "LOGAN HOUSE 15TH ST", "BLACK JACK PIZZA", "MOLLYS SPIRITS", "SQ *JOY FILL", "GOOD TIMES DR F", "MICRO CENTER", "Bang up to the Elephant", "SQ *PABLO'S COFFEE", "SQ *THE MOLECULE EFFECT", "SNARFS INSPIRED", "GRUBHUBIMPERIALDRAGON", "BOOKSHOP.ORG", "EINSTEIN BAGELS 1356", "AZUCAR BAKERY", "PARAMOUNT+", "KINDLE SVCS"}},
            {"Travel", new[] {"UNITED ", "CIRCLE K ", "ROYAL CARIBBEAN CRUISES", "CSA TRAVEL PROTECTION", "SPOTHERO"}},
            {"Utilities", new[] {"CITYOFDENVERWAST", "ARCADIA", "Microsoft*Microsoft 365", "CENTURYLINK", "MICROSOFT*SUBSCRIPTION", "APPLE.COM/BILL", "DNVRWTR SDPY"}},
            {"House Stuff", new[] {"ACE OF JEWELL", "MCGUCKIN", "HOME DEPOT", "GOODWILL LAKESIDE STORE", "TJMAXX", "MICHAELS STORES", "DOLLAR TREE", "TARGET", "AMZN Mktp US"}},
            {"Mortgage", new[] {"COOPER", "WF HOME MTG"}},
            {"Transportation", new[] {"ACH NISSAN", "MURPHY EXPRESS", "SPEEDWAY", "EXXON", "CHARGEPOINT", "DISCOUNT-TIRE", "MASABI_RTD", "AUTOZONE", "CONOCO", "PARKMOBILE", "LIME*RIDE", "MASABI RTD", "MTA*NYCT PAYGO ", "PARKI SANTA FE NM", "LYFT","LIM*RIDE ", "PUBLIC WORKS-PRKG METR", "TD AUTO FINANCE", "KING SOOPERS 0619 FUEL", "USAA P&C"}},
            {"Groceries", new[] { "MISFITS MARKET", "NATURAL GROCERS", "VILLAGE ROASTER COFFE", "TRADER JOE", "DROPPS","COSTCO", "GIRL SCOUT COOKIES", "SQ *JOY FILL", "SAFEWAY", "KING SOOPERS", "SPROUTS FARMERS MAR", "VIET HOA SUPERMARKET"}},
            {"CHECK - usually Groceries", new []{ "ZERO MARKET",  } },
            {"CHECK - usually Gifts", new []{ "DOLLARTREE", "UPS STORE", "THE WIZARD'S CHEST", "BROOKE REICHE DESIGN" } },
            {"CHECK - usually Clothes", new [] { "ARC THRIFT" } },
            {"CHECK - CheckAmazon", new [] { "AMAZON" } },
            {"CHECK - usually Transportation", new [] { "CITY OF FORT COLLINS FORT COLLINS " } },
            {"Health", new[] {"DOCTOR ON DEMAND", "OVERLAND ANIMAL HOSPITAL", "WALGREENS"}},
            {"Investments", new[] {"VANGUARD BUY"}},
            {"Cats", new[] {"Meowtel", "EMBRACE PET ", "PETS N' STUFF", "OVERLAND ANIMAL HOSPITAL", "CHEWY.COM"}},
            {"Gifts", new[] { "GARNET GLAZE ", "BARNES &amp; NOBLE", "HARBOR FREIGHT TOOLS"}},
            {"Lifestyle", new[] {"Audible", "SALLY BEAUTY", "Microsoft*Ultimate", "LIBRO.FM ", "GOOGLE *replika", "COLPARS HOBBYTOWN", "LATE FEE"}},
            {"Solar", new[] {"GOODLEAP 14"}},
            {"Income", new[] {"ACTALENT", "GATES CORP","KRISTIN HOERTH", "LLC DBA SPRO ENTRY"}},
            {"Education", new[]{ "CHATGPT SUBSCRIPTION",  "OPENAI", "PLURALSIGHT" } },
            {"Clothes", new []{ "GAP OUTLET", "EDDIE BAUER" } },
            {"REMOVE", new []{"ACH CAPITAL ONE TYPE: MOBILE PMT", "Payment Thank You-Mobile", "DEPOSIT HOME BANKING TRANSFER FROM SHARE" } },
            {"???", new[] {""}}
        };

    }
}
