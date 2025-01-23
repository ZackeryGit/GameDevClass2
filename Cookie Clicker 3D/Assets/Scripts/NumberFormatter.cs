using System;

public static class NumberFormatter
{
    
private static readonly string[] Suffixs =
{
    "",      // Below Thousand (10^0)
    "K",     // Thousand (10^3)
    "M",     // Million (10^6)
    "B",     // Billion (10^9)
    "T",     // Trillion (10^12)
    "Qa",    // Quadrillion (10^15)
    "Qi",    // Quintillion (10^18)
    "Sx",    // Sextillion (10^21)
    "Sp",    // Septillion (10^24)
    "Oc",    // Octillion (10^27)
    "No",    // Nonillion (10^30)
    "Dc",    // Decillion (10^33)
    "Ud",    // Undecillion (10^36)
    "Dd",    // Duodecillion (10^39)
    "Td",    // Tredecillion (10^42)
    "Qad",   // Quattuordecillion (10^45)
    "Qid",   // Quindecillion (10^48)
    "Sxd",   // Sexdecillion (10^51)
    "Spd",   // Septendecillion (10^54)
    "Ocd",   // Octodecillion (10^57)
    "Nod",   // Novemdecillion (10^60)
    "Vg",    // Vigintillion (10^63)
    "Uv",    // Unvigintillion (10^66)
    "Duv",   // Duovigintillion (10^69)
    "Tgv",   // Tresvigintillion (10^72)
    "Qav",   // Quattuorvigintillion (10^75)
    "Qiv",   // Quinvigintillion (10^78)
    "Sxv",   // Sexvigintillion (10^81)
    "Spv",   // Septenvigintillion (10^84)
    "Ocv",   // Octovigintillion (10^87)
    "Nov",   // Novemvigintillion (10^90)
    "Trg",   // Trestrigintillion (10^93)
    "Qtrg",  // Quattuortrigintillion (10^96)
    "Qtrig", // Quinttrigintillion (10^99)
    "Sxtg",  // Sextrigintillion (10^102)
    "Septg", // Septentrigintillion (10^105)
    "Octg",  // Octotrigintillion (10^108)
    "Ntg",   // Novemtrigintillion (10^111)
    "Vgt",   // Vigintitrigintillion (10^114)
    "Uvt",   // Unvigintitrigintillion (10^117)
    "Duvt",  // Duovigintitrigintillion (10^120)
    "Tgvt",  // Tresvigintitrigintillion (10^123)
    "Qavt",  // Quattuorvigintitrigintillion (10^126)
    "Qivt",  // Quinvigintitrigintillion (10^129)
    "Sxvt",  // Sexvigintitrigintillion (10^132)
    "Spvt",  // Septenvigintitrigintillion (10^135)
    "Ocvt",  // Octovigintitrigintillion (10^138)
    "Novt",  // Novemvigintitrigintillion (10^141)
    "Trgt",  // Trestrigintitrigintillion (10^144)
    "Qtrgt", // Quattuortrigintitrigintillion (10^147)
    "Qtrigt",// Quinttrigintitrigintillion (10^150)
    "Sxtgt", // Sextrigintitrigintillion (10^153)
    "Septgt",// Septentrigintitrigintillion (10^156)
    "Octgt", // Octotrigintitrigintillion (10^159)
    "Ntgt",  // Novemtrigintitrigintillion (10^162)
    "Vgtg",  // Vigintitrigintitrigintillion (10^165)
    "Uvtg",  // Unvigintitrigintitrigintillion (10^168)
    "Duvtg", // Duovigintitrigintitrigintillion (10^171)
    "Tgvtg", // Tresvigintitrigintitrigintillion (10^174)
    "Qavtg", // Quattuorvigintitrigintitrigintillion (10^177)
    "Qivtg", // Quinvigintitrigintitrigintillion (10^180)
    "Sxvtg", // Sexvigintitrigintitrigintillion (10^183)
    "Spvtg", // Septenvigintitrigintitrigintillion (10^186)
    "Ocvtg", // Octovigintitrigintitrigintillion (10^189)
    "Novtg", // Novemvigintitrigintitrigintillion (10^192)
    "Trgtg", // Trestrigintitrigintitrigintillion (10^195)
    "Qtrgtg",// Quattuortrigintitrigintitrigintillion (10^198)
    "Qtrigtg",// Quinttrigintitrigintitrigintillion (10^201)
    "Sxtgtg", // Sextrigintitrigintitrigintillion (10^204)
    "Septgtg",// Septentrigintitrigintitrigintillion (10^207)
    "Octgtg", // Octotrigintitrigintitrigintillion (10^210)
    "Ntgtg",  // Novemtrigintitrigintitrigintillion (10^213)
    "Vgtgg",  // Vigintitrigintitrigintitrigintillion (10^216)
    "Uvtgg",  // Unvigintitrigintitrigintitrigintillion (10^219)
    "Duvtgg", // Duovigintitrigintitrigintitrigintillion (10^222)
    "Tgvtgg", // Tresvigintitrigintitrigintitrigintillion (10^225)
    "Qavtgg", // Quattuorvigintitrigintitrigintitrigintillion (10^228)
    "Qivtgg", // Quinvigintitrigintitrigintitrigintillion (10^231)
    "Sxvtgg", // Sexvigintitrigintitrigintitrigintillion (10^234)
    "Spvtgg", // Septenvigintitrigintitrigintitrigintillion (10^237)
    "Ocvtgg", // Octovigintitrigintitrigintitrigintillion (10^240)
    "Novtgg", // Novemvigintitrigintitrigintitrigintillion (10^243)
    "Trgtgg", // Trestrigintitrigintitrigintitrigintillion (10^246)
    "Qtrgtgg",// Quattuortrigintitrigintitrigintitrigintillion (10^249)
    "Qtrigtgg",// Quinttrigintitrigintitrigintitrigintillion (10^252)
    "Sxtgtgg", // Sextrigintitrigintitrigintitrigintillion (10^255)
    "Septgtgg",// Septentrigintitrigintitrigintitrigintillion (10^258)
    "Octgtgg", // Octotrigintitrigintitrigintitrigintillion (10^261)
    "Ntgtgg",  // Novemtrigintitrigintitrigintitrigintillion (10^264)
    "Vgtggg",  // Vigintitrigintitrigintitrigintitrigintillion (10^267)
    "Uvtggg",  // Unvigintitrigintitrigintitrigintitrigintillion (10^270)
    "Duvtggg", // Duovigintitrigintitrigintitrigintitrigintillion (10^273)
    "Tgvtggg", // Tresvigintitrigintitrigintitrigintitrigintillion (10^276)
    "Qavtggg", // Quattuorvigintitrigintitrigintitrigintitrigintillion (10^279)
    "Qivtggg", // Quinvigintitrigintitrigintitrigintitrigintillion (10^282)
    "Sxvtggg", // Sexvigintitrigintitrigintitrigintitrigintillion (10^285)
    "Spvtggg", // Septenvigintitrigintitrigintitrigintitrigintillion (10^288)
    "Ocvtggg", // Octovigintitrigintitrigintitrigintitrigintillion (10^291)
    "Novtggg", // Novemvigintitrigintitrigintitrigintitrigintillion (10^294)
    "Trgtggg",  // Trestrigintitrigintitrigintitrigintitrigintillion (10^297)
    "Qtrgtggg", // Quattuortrigintitrigintitrigintitrigintitrigintillion (10^300)
    "Qtrigtggg", // Quinttrigintitrigintitrigintitrigintitrigintillion (10^303)
    "Sxtgtggg"  // Sextrigintitrigintitrigintitrigintitrigintillion (10^306)
};
    
    public static string AbbreviatedFormat(double num){

        int suffixIndex = 0;

        while (num >= 1000 && suffixIndex < Suffixs.Length){
            num /= 1000;
            suffixIndex ++;
        }

        
        // 999,999 999.999 / .1
        if (num >= 100) {
            num = Math.Floor(num * 10) / 10;
            
        }else if (num >= 10) {
            num = Math.Floor(num * 100) / 100;  
        } else {
            num = Math.Floor(num * 1000) / 1000;  
        }
        
        return num + Suffixs[suffixIndex];
    }

}
