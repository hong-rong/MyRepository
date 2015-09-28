using System;

public class DecipherabilityEasy
{
    public string check(string s, string t)
    {
        //solution one
        //for (int i = 0; i < s.Length; i++)
        //{
        //    string temp = s.Substring(0, i) + s.Substring(i + 1);

        //    if (t == temp)
        //        return "Possible";
        //}

        //return "Impossible";

        //solution two
        if (s.Length - t.Length != 1) return "Impossible";

        bool skipped = false;
        for (int i = 0; i < t.Length; i++)
        {
            if (!skipped && t[i] != s[i])
                skipped = true;

            if (skipped)
                if (t[i] != s[i + 1])
                    return "Impossible";
        }

        return "Possible";

        //solution three
        //if (s.Length - t.Length != 1) return "Impossible";

        //bool skipped = false;
        //for (int i = 0; i < t.Length; i++)
        //{
        //    if (skipped)
        //    {
        //        if (t[i] != s[i + 1])
        //            return "Impossible";
        //    }
        //    else if (t[i] != s[i])
        //    {
        //if (t[i] != s[i + 1])//this shouldn't be missing
        //    return "Impossible";

        //        skipped = true;
        //    }
        //}

        //return "Possible";
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new DecipherabilityEasy()).check("sunuke", "snuke"), "Possible");
            eq(1, (new DecipherabilityEasy()).check("snuke", "skue"), "Impossible");
            eq(2, (new DecipherabilityEasy()).check("snuke", "snuke"), "Impossible");
            eq(3, (new DecipherabilityEasy()).check("snukent", "snuke"), "Impossible");
            eq(4, (new DecipherabilityEasy()).check("aaaaa", "aaaa"), "Possible");
            eq(5, (new DecipherabilityEasy()).check("aaaaa", "aaa"), "Impossible");
            eq(6, (new DecipherabilityEasy()).check("topcoder", "tpcoder"), "Possible");
            eq(7, (new DecipherabilityEasy()).check("singleroundmatch", "singeroundmatc"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("aa", "a"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("ab", "a"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("ab", "b"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("abc", "ab"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("ab", "c"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abc", "ac"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("abc", "b"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("ab", "c"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abc", "aac"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("ildzzupqqopaizfrwzmebdkuhjjmagwitsbmmrzbgrifpxyk", "ildzzupqqopaifrwzmebdkuhjjmagwitsbmmrzbgrifpxyk"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("dvyqkcuowtszmmarlhzmgmnqqnxrqkn", "dvqkcuowtszmmarlhzmgmnqqnxrqkn"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("feipwxwoghejqcmaxvavqtwfgejhohyuyvufvdnl", "feipxwoghejqcmaxvavqtwfgejhohyuyvufvdnl"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("jjvmjfcqlklwycceifpolickmabpujypdddkiksgowhduvf", "jjvmjcqlklwycceifpolickmabpujypdddkiksgowhduvf"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("gtlaozuyoasojsvtxijopwxaeyfchxszmg", "gtlaozuyoaojsvtxijopwxaeyfchxszmg"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("tsxjarccqzjveufxeaydzlwimsygniooihykmcsbwbtdprj", "tsxjarccqzjveufxeaydzlwimsygnioohykmcsbwbtdprj"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("oeomnyundnxvqnpjbsddvslharvdmltqpmkilki", "oeomnyundnxvqnpjbsddvslhavdmltqpmkilki"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("rdqhdmvzfjzlojmakdijvobgqdjkuffthkuohffzcpurkso", "rdqhdmvzfjzlojmakdijvobgqdjkuffthkohffzcpurkso"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("yqtikjgerlfninryzowihtjzrgofrgaggtymhrxcczzclsw", "yqtikjgerlfninryzowihtjzrgofrgggtymhrxcczzclsw"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("ydxzlcnhnhpjatmkgnhqbeecsdctepnxsa", "ydxzlcnhnhpjatmkgnhqbeecsdctenxsa"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("rqxvzargeewzkuupotpsmedcirebocvsb", "rqxvzargeewzkuuotpsmedcirebocvsb"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("tzwvuvipfxggtufhhcyrtvbbogdeomdngdvvmkchct", "tzwvuvipfxggtufhcyrtvbbogdeomdngdvvmkchct"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("iuxpfdqlerypakpmavlejtfecsmnyersikytwucoddu", "iuxpfdqlerypakpmavlejtfecsmnyersikytwuoddu"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("gjwoodxzmgnwrzjrkuspvzqzqfekzmnfjzof", "gjwoodxzmgnwrzjrkuspvzqzqekzmnfjzof"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("qfpmqegpfjjtbxyfpzwmnavxpinffpccyqlpvjqxikcjphlbg", "qpmqegpfjjtbxyfpzwmnavxpinffpccyqlpvjqxikcjphlbg"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("exqbugsgoydmkeetjlpjppebocwtshmfhrwuyyofwraykeb", "exqbugsgoydmkeetjlpjppebcwtshmfhrwuyyofwraykeb"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("kpfbcumoyohhphyxobjxszmvaqhnycgwdwlztljxi", "kpfbcumoyohhphyxobjxszmvaqnycgwdwlztljxi"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("hunrnueavcgknzdnxynllqaceveymjarezosbdqrwl", "hunrnueavcgnzdnxynllqaceveymjarezosbdqrwl"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("oebybdgxrnezovpokxygqaidnqnuqbqpqayjco", "oebybdgxrnezovpokxygaidnqnuqbqpqayjco"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("xtbxwjvnsueklslwaqdwlaknavvohwszkqjmtubhu", "xtbxwjvnsuekllwaqdwlaknavvohwszkqjmtubhu"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("bbxhfyfhvcohnikfidtmlsdvmhkkyfokaewxopdjjilgf", "bbxhfyfhvcohnikfidtmlsdvmhkkyfkaewxopdjjilgf"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("subedzqbrlfffroikjvxebvbrdfheucxgbptmrccdmnpoxpd", "subedzqbrlfffroikjvxebvbrdfheucgbptmrccdmnpoxpd"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("smtzzvvvyzvdsntpzciwwzgulsjnserwiycinchcyeyoqd", "smtzzvvvyzvdsntpzciwwzguljnserwiycinchcyeyoqd"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("bjxpmdkexyjqdjsqvvdnhygzddmvmerzgum", "bjxpmdkeyjqdjsqvvdnhygzddmvmerzgum"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("bjusjvvvmmqvrifxuslxcyfkpgzeagrhz", "bjusjvvvmmqvrifxuslxcyfkpgzeaghz"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("scwdsfiifsgxooxhalbrpfhkkvcokpbwuvztbndfpw", "scwdsiifsgxooxhalbrpfhkkvcokpbwuvztbndfpw"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("ijzuunzjsjbrclauzzfszranpvyaudcqdhmpntacbwsy", "ijzuunzjsjbrclauzzfszranpvyadcqdhmpntacbwsy"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("svfgfqftrygfeklvutbntlpedjrvdhgsib", "svfgfftrygfeklvutbntlpedjrvdhgsib"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("dbhevbgilatmzjvdmmvvahdcgzobwwhupvzsaygv", "dbhevbglatmzjvdmmvvahdcgzobwwhupvzsaygv"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("iiyokoiyo", "iyokoiyo"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("iiyokoiyo", "iiyokoiy"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("ccacbacaaaacca", "cccbacaaaacca"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("caaabbbacbaababaccccabacabacabbbbbab", "caaabbbacbaababaccccbbacaaacabbbbab"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abaaabcaabccac", "abaaaacaabccb"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("cccccaacabaacaacbbcbaaabaacabaacbbbbbabcaaa", "cccaaaccbaacaacbbcbaaabaacabaacbbbbbabcaaa"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("cacbababaaaccacbccbbcbacb", "cacbababaaccbcbccbbcbaca"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("aabcacbacbbbbbbcccbcccacbcaaababcbabcbbabbbbb", "aabcacbacbbcbbbcccbcbcacbcaaababcbabbbabbbbb"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("cacbbaacaaccaacbacababbbbbabccccaaabba", "cacbbaacaaccaacbacababbbbabcbccaaabca"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("bcccccbaabcccacbbaabcaccacacaaaabacccaa", "accccbaabcccacbbaabcaccacacaababacccaa"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("aabccccbabaabacaab", "aabccccbabaaacaab"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("baabcbcab", "aabcbcbb"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("cbacbccb", "cbacccb"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("cbaabccc", "abcabcc"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("bcbacbcbccbbbabccabcbaab", "bcbbbcbccbbcabccabcbaab"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("acaacbbccab", "aaccbbccab"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("aabbbacbcacabbbbccbbabababc", "baabbcbcacabbbbccbbabababc"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("cccaabcaccbbcccacaaaacbcabc", "cacaabcaccbbcccacaaaccbcbc"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("bccbabbbbacacaabccbbbabacaabbc", "bcbbabbbacacaabccbbcabacaabbc"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("bcccacccbabbaaaccacacbcbaaaacbcaccbaababbbcbcbcb", "bcccacccbabbaaaccacacbcbaaaabcaccbaababbbcbcbcb"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("babccaccbbbbacaacaabaccbacacbacbc", "babccaccbbbbacaacaabacccaacbacbb"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("babbabbacbccbabaacacbbaccacbcbbaaccaccbcccbb", "babbabbacbccbabaacacbbaccacbcbbaaccaccbccbb"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("bcacbbacc", "bcacbbac"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("ccbabbaaacbbaaaaabaaaba", "ccbabbaaacbbaaaaaaaaba"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("caaaaaabcbcbcabcbabbabacaacbcbabcababbbabacbcbbba", "caaaaaabcbcacabcbabbabacaacbcbbbcababbbababcbbba"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("ccbbbcaacaacbaaaaccccbabaccacccbacccc", "ccbbbcaaccaabaaaaccccbabaccacccacccc"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("bbaaccbcaccbbbcababbcaaccaabcbbabacababab", "bbaaccbcacbbbcababbcaaccaabcbbabacababab"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("cacaabbaaacbbc", "cacaabbaaabbc"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("cabcbabacbcaabbcbbbaababaaabaabbbabbaabcbccacccb", "ccbcabacbcaabbcbbbaababaaabaabbbabbaabcbcaacccb"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("cbcbbcaabcbcabbbccccacbcbaacccbbc", "cbcbccaabcbabbbcbccacbcbaacccbbc"), "Impossible");

            eq(8, (new DecipherabilityEasy()).check("baabbacbcabcaacaaaba", "baabbabcabcaacaacba"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("bcbbaccbcbccacbbbbbccccbbaa", "bcbbaccbcbccbcbabbbccccbba"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("bbabaaabbbabbabbaaabaabbbaaabaabbb", "abaaabaabbbbaaaaa"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("bbbabbabbbabaabbaabaaabbbbba", "ababaaabaaaaabbaabbabbbaa"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("bbbbbabaabaabbbabaaabbabbabbabbbbabaababaa", "baaaabbabbaabbaabaaabbbbaab"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("bbbabaaaababaaaaaaaa", "bababababbbaababbbbbabbaaaabbabbbbbaabbabbbabbaa"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abaababbaaabaabaaaaaaabaabbbaababaaaabbaaaaab", "bababbbaabbbababbbbbabbbababbbbaaaaabbbbababb"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abaabaaaabbaabaabaaaaabbbbabbbaabbbbaaabbbaa", "bbabbabaabaaaabaaabaabbabaabbaababaabababaabab"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("aabbaabbbbabbaaaabbaaaababbb", "aaaaaaabbabbbabbbabbaabbbabbbababababbaaab"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("bbbbaabbababbbbbbbbbbbbabaaabbbb", "bbbabbabababba"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abbaababbbaabaaababbbaabbbaabbabbbbbbbbaba", "aabbbaaaababbaabbbbab"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("bbabbbbabbaaaabbaaabaaabbaaababa", "aaabaaababaabaaaaab"), "Impossible");


            eq(8, (new DecipherabilityEasy()).check("a", "a"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("a", "b"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("a", "ac"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("a", "ca"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("a", "bc"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("sunuke", "sunuke"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("ss", "ss"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abcd", "adc"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("ab", "aaba"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("nnnn", "nnnn"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abcddddd", "abcd"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("aa", "aaa"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("pera", "pea"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("abc", "abcabcababcabcababcabcababcabcababcabcababcabcab"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abcde", "bcde"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("abc", "aabc"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("ab", "d"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abcr", "abcde"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abc", "dcba"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("aabc", "acb"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("qwerty", "qwery"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("asdfafghh", "asdaafgh"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("aaa", "aa"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("aaab", "aaaa"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abcdef", "abc"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abc", "ae"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abcd", "gcd"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("cabc", "acb"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("aaaaa", "aaaab"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("aaa", "aaaaa"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("ac", "b"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abc", "abcd"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("accb", "adb"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abcd", "abd"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("hello", "heoo"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abecd", "bcde"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abc", "bc"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("aaaaaaa", "aaaaaaa"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("adsfefef", "asdfefef"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abc", "acdef"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("snuke", "snuk"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("abcd", "abc"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("snnke", "suke"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abaa", "ab"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("aab", "aaaa"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abc", "abdck"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abcd", "cab"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("aaaabxaaaa", "aaaacaaaa"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("ahmad", "amsd"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("bcato", "bceo"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("aaa", "aaaa"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("aabaa", "aaa"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("ababa", "aaaa"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("perap", "peap"), "Possible");
            eq(8, (new DecipherabilityEasy()).check("ash", "ashwin"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("hhh", "h"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("aaa", "ab"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("howa", "howw"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abcde", "abc"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("aabaa", "aaaaa"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("aaaa", "aa"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("bab", "aa"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("asua", "usa"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("pqrs", "prstt"), "Impossible");
            eq(8, (new DecipherabilityEasy()).check("abcde", "abke"), "Impossible");
            //eq(8, (new DecipherabilityEasy()).check(), "Possible");
        }
        catch (Exception exx)
        {
            System.Console.WriteLine(exx);
            System.Console.WriteLine(exx.StackTrace);
        }

        Console.ReadKey();
    }
    private static void eq(int n, object have, object need)
    {
        if (eq(have, need))
        {
            Console.WriteLine("Case " + n + " passed.");
        }
        else
        {
            Console.Write("Case " + n + " failed: expected ");
            print(need);
            Console.Write(", received ");
            print(have);
            Console.WriteLine();
        }
    }
    private static void eq(int n, Array have, Array need)
    {
        if (have == null || have.Length != need.Length)
        {
            Console.WriteLine("Case " + n + " failed: returned " + have.Length + " elements; expected " + need.Length + " elements.");
            print(have);
            print(need);
            return;
        }
        for (int i = 0; i < have.Length; i++)
        {
            if (!eq(have.GetValue(i), need.GetValue(i)))
            {
                Console.WriteLine("Case " + n + " failed. Expected and returned array differ in position " + i);
                print(have);
                print(need);
                return;
            }
        }
        Console.WriteLine("Case " + n + " passed.");
    }
    private static bool eq(object a, object b)
    {
        if (a is double && b is double)
        {
            return Math.Abs((double)a - (double)b) < 1E-9;
        }
        else
        {
            return a != null && b != null && a.Equals(b);
        }
    }
    private static void print(object a)
    {
        if (a is string)
        {
            Console.Write("\"{0}\"", a);
        }
        else if (a is long)
        {
            Console.Write("{0}L", a);
        }
        else
        {
            Console.Write(a);
        }
    }
    private static void print(Array a)
    {
        if (a == null)
        {
            Console.WriteLine("<NULL>");
        }
        Console.Write('{');
        for (int i = 0; i < a.Length; i++)
        {
            print(a.GetValue(i));
            if (i != a.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine('}');
    }
    // END CUT HERE
}
