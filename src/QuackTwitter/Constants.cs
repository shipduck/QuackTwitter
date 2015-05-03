using System;
using System.Reflection;

namespace QuackTwitter
{
    class Constants
    {
        public const String BaseURL = "https://api.twitter.com/1.1";
        public const String OAuthURL = "https://api.twitter.com/oauth/authorize";
        public const String StatusesURL = BaseURL + "/statuses";
        public const String MediaURL = "https://upload.twitter.com/1.1/media";
        public const String DirectMessagesURL = BaseURL + "/direct_messages";
        public const String SearchURL = BaseURL + "/search";
        public const String FriendshipsURL = BaseURL + "/friendships";
        public const String FriendsURL = BaseURL + "/friends";
        public const String FollowersURL = BaseURL + "/followers";
        public const String AccountURL = BaseURL + "/account";
        public const String BlocksURL = BaseURL + "/blocks";
        public const String UsersURL = BaseURL + "/users";
        public const String MutesURL = BaseURL + "/mutes";
        public const String FavoritesURL = BaseURL + "/favorites";
        public const String ListsURL = BaseURL + "/lists";
        public const String SavedSearchesURL = BaseURL + "/saved_searches";
        public const String GeoURL = BaseURL + "/geo";
        public const String TrendsURL = BaseURL + "/trends";
        public const String ApplicationURL = BaseURL + "/application";
        public const String HelpURL = BaseURL + "/help";
		public const String UserStreamURL = "https://userstream.twitter.com/1.1/user.json";
    }

    [AttributeUsage(AttributeTargets.Field)]
    internal class EnumValueAttribute : Attribute
    {
        public EnumValueAttribute(string val)
        {
            value = val;
        }

        public string value { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Enum)]
    internal class EnumValueMappedAttribute : Attribute
    {
        public EnumValueMappedAttribute()
        { }
    }

    [EnumValueMapped]
    public enum Language
    {
        [EnumValue("ab")]
        Abkhazian,

        [EnumValue("aa")]
        Afar,

        [EnumValue("af")]
        Afrikaans,

        [EnumValue("ak")]
        Akan,

        [EnumValue("sq")]
        Albanian,

        [EnumValue("am")]
        Amharic,

        [EnumValue("ar")]
        Arabic,

        [EnumValue("an")]
        Aragonese,

        [EnumValue("hy")]
        Armenian,

        [EnumValue("as")]
        Assamese,

        [EnumValue("av")]
        Avaric,

        [EnumValue("ae")]
        Avestan,

        [EnumValue("ay")]
        Aymara,

        [EnumValue("az")]
        Azerbaijani,

        [EnumValue("bm")]
        Bambara,

        [EnumValue("ba")]
        Bashkir,

        [EnumValue("eu")]
        Basque,

        [EnumValue("be")]
        Belarusian,

        [EnumValue("bn")]
        Bengali,

        [EnumValue("bh")]
        BihariLanguages,

        [EnumValue("bi")]
        Bislama,

        [EnumValue("nb")]
        Bokmal,
        [EnumValue("nb")]
        NorwegianBokmal,

        [EnumValue("bs")]
        Bosnian,

        [EnumValue("br")]
        Breton,

        [EnumValue("bg")]
        Bulgarian,

        [EnumValue("my")]
        Burmese,


        [EnumValue("es")]
        Castilian,
        [EnumValue("es")]
        Spanish,

        [EnumValue("ca")]
        Catalan,
        [EnumValue("ca")]
        Valencian,

        [EnumValue("km")]
        CentralKhmer,

        [EnumValue("ch")]
        Chamorro,

        [EnumValue("ce")]
        Chechen,

        [EnumValue("ny")]
        Chewa,
        [EnumValue("ny")]
        Chichewa,
        [EnumValue("ny")]
        Nyanja,

        [EnumValue("zh")]
        Chinese,

        [EnumValue("za")]
        Chuang,
        [EnumValue("za")]
        Zhuang,

        [EnumValue("cu")]
        ChurchSlavic,
        [EnumValue("cu")]
        ChurchSlavonic,

        [EnumValue("cv")]
        Chuvash,

        [EnumValue("kw")]
        Cornish,

        [EnumValue("co")]
        Corsican,

        [EnumValue("cr")]
        Cree,

        [EnumValue("hr")]
        Croatian,

        [EnumValue("cs")]
        Czech,

        [EnumValue("da")]
        Danish,

        [EnumValue("dv")]
        Dhivehi,
        [EnumValue("dv")]
        Divehi,
        [EnumValue("dv")]
        Maldivian,

        [EnumValue("nl")]
        Dutch,
        [EnumValue("nl")]
        Flemish,

        [EnumValue("dz")]
        Dzongkha,

        [EnumValue("en")]
        English,

        [EnumValue("eo")]
        Esperanto,

        [EnumValue("et")]
        Estonian,

        [EnumValue("ee")]
        Ewe,

        [EnumValue("fo")]
        Faroese,

        [EnumValue("fj")]
        Filipino,

        [EnumValue("fi")]
        Finnish,

        [EnumValue("fr")]
        French,

        [EnumValue("ff")]
        Fulah,

        [EnumValue("gd")]
        Gaelic,
        [EnumValue("gd")]
        ScottishGaelic,

        [EnumValue("gl")]
        Galician,

        [EnumValue("lg")]
        Ganda,

        [EnumValue("ka")]
        Georgian,

        [EnumValue("de")]
        German,

        [EnumValue("ki")]
        Gikuyu,
        [EnumValue("ki")]
        Kikuyu,

        [EnumValue("el")]
        Greek,

        [EnumValue("kl")]
        Greenlandic,

        [EnumValue("gn")]
        Guarani,

        [EnumValue("gu")]
        Gujarati,

        [EnumValue("ht")]
        Haitian,
        [EnumValue("ht")]
        HaitianCreole,

        [EnumValue("ha")]
        Hausa,

        [EnumValue("he")]
        Hebrew,

        [EnumValue("hz")]
        Herero,

        [EnumValue("hi")]
        Hindi,

        [EnumValue("ho")]
        HiriMotu,

        [EnumValue("hu")]
        Hungarian,

        [EnumValue("is")]
        Icelandic,

        [EnumValue("io")]
        Ido,

        [EnumValue("ig")]
        Igbo,

        [EnumValue("id")]
        Indonesian,

        [EnumValue("ia")]
        Ingush,

        [EnumValue("ie")]
        Interlingue,
        [EnumValue("ie")]
        Occidental,

        [EnumValue("iu")]
        Inuktitut,

        [EnumValue("ik")]
        Inupiaq,

        [EnumValue("ga")]
        Irish,

        [EnumValue("it")]
        Italian,

        [EnumValue("ja")]
        Japanese,

        [EnumValue("jv")]
        Javanese,

        [EnumValue("kl")]
        Kalaallisut,

        [EnumValue("kn")]
        Kannada,

        [EnumValue("kr")]
        Kanuri,

        [EnumValue("ks")]
        Kashmiri,

        [EnumValue("kk")]
        Kazakh,

        [EnumValue("rw")]
        Kinyarwanda,

        [EnumValue("ky")]
        Kirghiz,
        [EnumValue("ky")]
        Kyrgyz,

        [EnumValue("kv")]
        Komi,

        [EnumValue("kj")]
        Kuanyama,
        [EnumValue("kj")]
        Kwanyama,

        [EnumValue("ku")]
        Kuridish,

        [EnumValue("lo")]
        Lao,

        [EnumValue("la")]
        Latin,

        [EnumValue("lv")]
        Latvian,

        [EnumValue("lb")]
        Letzeburgesch,
        [EnumValue("lb")]
        Luxembourgish,

        [EnumValue("li")]
        Limburgan,
        [EnumValue("li")]
        Limburger,
        [EnumValue("li")]
        Limburgish,

        [EnumValue("lu")]
        LubaKatanga,

        [EnumValue("mk")]
        Macedonian,

        [EnumValue("mg")]
        Malagasy,

        [EnumValue("ms")]
        Malay,

        [EnumValue("ml")]
        Malayalam,

        [EnumValue("mt")]
        Maltese,

        [EnumValue("gv")]
        Manx,

        [EnumValue("mi")]
        Maori,

        [EnumValue("mr")]
        Marathi,

        [EnumValue("mh")]
        Marshallese,

        [EnumValue("ro")]
        Moldavian,
        [EnumValue("ro")]
        Moldovan,
        [EnumValue("ro")]
        Romanian,

        [EnumValue("mn")]
        Mongolian,

        [EnumValue("na")]
        Nauru,

        [EnumValue("nv")]
        Navaho,
        [EnumValue("nv")]
        Navajo,

        [EnumValue("nd")]
        NodebeleNorth,
        [EnumValue("nd")]
        NorthNdebele,

        [EnumValue("nr")]
        NodebeleSouth,
        [EnumValue("nr")]
        SouthNodebele,

        [EnumValue("ng")]
        Ndonga,

        [EnumValue("ne")]
        Nepali,

        [EnumValue("se")]
        NorthernSami,

        [EnumValue("no")]
        Norwegian,

        [EnumValue("nn")]
        NorwegianNynorsk,
        [EnumValue("nn")]
        NynorskNorwegian,

        [EnumValue("ii")]
        Nuosu,
        [EnumValue("ii")]
        SichuanYi,

        [EnumValue("oc")]
        Occitan,

        [EnumValue("oj")]
        Ojibwa,

        [EnumValue("cu")]
        OldBulgarign,
        [EnumValue("cu")]
        OldChurchSlavonic,
        [EnumValue("cu")]
        OldSlavonic,

        [EnumValue("or")]
        Oriya,

        [EnumValue("om")]
        Oromo,

        [EnumValue("os")]
        Ossetian,
        [EnumValue("os")]
        Ossetic,

        [EnumValue("pi")]
        Pali,

        [EnumValue("ps")]
        Pashto,

        [EnumValue("fa")]
        Persian,

        [EnumValue("pl")]
        Polish,

        [EnumValue("pt")]
        Portuguese,

        [EnumValue("pa")]
        Punjabi,

        [EnumValue("ps")]
        Pushto,

        [EnumValue("qu")]
        Quechua,

        [EnumValue("rm")]
        Romansh,

        [EnumValue("rn")]
        Rundi,

        [EnumValue("ru")]
        Russian,

        [EnumValue("sm")]
        Samoan,

        [EnumValue("sg")]
        Sango,

        [EnumValue("sa")]
        Sanskrit,

        [EnumValue("sc")]
        Sardinian,

        [EnumValue("sr")]
        Serbian,

        [EnumValue("sn")]
        Shona,

        [EnumValue("sd")]
        Sindhi,

        [EnumValue("si")]
        Sinhala,
        [EnumValue("si")]
        Sinhalese,

        [EnumValue("sk")]
        Slovak,

        [EnumValue("sl")]
        Slovenian,

        [EnumValue("so")]
        Somali,

        [EnumValue("st")]
        SothoSouthern,

        [EnumValue("su")]
        Sundanese,

        [EnumValue("sw")]
        Swahili,

        [EnumValue("ss")]
        Swati,

        [EnumValue("sv")]
        Swedish,

        [EnumValue("tl")]
        Tagalog,

        [EnumValue("ty")]
        Tahitian,

        [EnumValue("tg")]
        Tajik,

        [EnumValue("ta")]
        Tamil,

        [EnumValue("tt")]
        Tatar,

        [EnumValue("te")]
        Telugu,

        [EnumValue("th")]
        Thai,

        [EnumValue("bo")]
        Tibetan,

        [EnumValue("ti")]
        Tigrinya,

        [EnumValue("to")]
        Tonga,

        [EnumValue("ts")]
        Tsonga,

        [EnumValue("tn")]
        Tswana,

        [EnumValue("tr")]
        Turkish,

        [EnumValue("tk")]
        Turkmen,

        [EnumValue("tw")]
        Twi,

        [EnumValue("ug")]
        Uighur,

        [EnumValue("uk")]
        Ukrainian,

        [EnumValue("ur")]
        Urdu,

        [EnumValue("ug")]
        Uyghur,

        [EnumValue("uz")]
        Uzbek,

        [EnumValue("ve")]
        Venda,

        [EnumValue("vi")]
        Vietnamese,

        [EnumValue("vo")]
        Volapuk,

        [EnumValue("wa")]
        Waloon,

        [EnumValue("cy")]
        Weish,

        [EnumValue("fy")]
        WesternFrisian,

        [EnumValue("wo")]
        Wolof,

        [EnumValue("xh")]
        Xhosa,

        [EnumValue("yi")]
        Yiddish,

        [EnumValue("yo")]
        Yoruba,

        [EnumValue("zu")]
        Zulu
    }

    public class Color
    {
        public Color(string color)
        {
        }

        public Color(Byte r, Byte g, Byte b)
        {
            Red = r;
            Green = g;
            Blue = b;
        }

        public Byte Red { get; set; }
        public Byte Green { get; set; }
        public Byte Blue { get; set; }

        public override string ToString()
        {
            return string.Format("{0:X02}{1:X02}{2:X02}", Red, Green, Blue);
        }
    }

    public static class ConversionToString
    {
        public static string EnumValueMapToString(object enumval)
        {
            MemberInfo member = null;
            foreach(var temp in enumval.GetType().GetTypeInfo().DeclaredMembers)
            {
                if(temp.Name == enumval.ToString())
                {
                    member = temp;
                    break;
                }
            }

            if (member != null)
            {
                EnumValueAttribute attr = member.GetCustomAttribute<EnumValueAttribute>() as EnumValueAttribute;
                if (attr != null)
                {
                    return attr.value;
                }
            }

            return enumval.ToString();
        }
    }
}
