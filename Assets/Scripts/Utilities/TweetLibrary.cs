using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TweetLibrary {

    private static string[] _tweetsList = new string[] { 
        "\"The U.S. cannot allow EBOLA infected people back. People that go to far away places to help out are great-but must suffer the consequences!\"",
        "\"Happy #CincoDeMayo! The best taco bowls are made in Trump Tower Grill. I love Hispanics!\"",
        "\"Wow, President Obama's brother, Malik, just announced that he is voting for me. Was probably treated badly by president-like everybody else!\"",
        "\".@BetteMidler talks about my hair but I'm not allowed to talk about her ugly face or body --- so I won't. Is this a double standard?\"",
        "\"If crazy @megynkelly didn't cover me so much on her terrible show, her ratings would totally tank. She is so average in so many ways!\"",
        "\"Healthy young child goes to doctor, gets pumped with massive shot of many vaccines, doesn’t feel good and changes – AUTISM. Many such cases!\"",
        "\".@ariannahuff is unattractive both inside and out. I fully understand why her former husband left her for a man- he made a good decision.\"",
        "\"Sorry losers and haters, but my I.Q. is one of the highest -and you all know it! Please don’t feel so stupid or insecure,it’s not your fault\"",
        "\"Windmills are the greatest threat in the US to both bald and golden eagles. Media claims fictional ‘global warming’ is worse.\"",
        "\"If the morons who killed all of those people at Charlie Hedbo would have just waited, the magazine would have folded – no money, no success!\"",
        "\"Every time I speak of the haters and losers I do so with great love and affection. They cannot help the fact that they were born fucked up!\"",
        "\"An 'extremely credible source' has called my office and told me that @BarackObama's birth certificate is a fraud.\"",
        "\"Everyone knows I am right that Robert Pattinson should dump Kristen Stewart. In a couple of years, he will thank me. Be smart, Robert.\"",
        "\"@realDonaldTrump: I would like to extend my best wishes to all, even the haters and losers, on this special date, September 11th.\"",
        "\"This election is a total sham and a travesty. We are not a democracy!\"",
        "\"I have never seen a thin person drinking Diet Coke.\"",
        "\"Thanks- many are saying I'm the best 140 character writer in the world. It's easy when it's fun.\""
    };

    public static string GetRandomTweet () {
        var rand = Random.Range(0, _tweetsList.Length);

        return _tweetsList[rand];
    }
}
