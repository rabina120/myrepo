﻿$(function () { var A = ""; $("form").on("keyup", ".nepaliMonth", function (P) { if (8 == P.keyCode) return !1; P.keyCode; var R = $(this), i = R.val(), r = i.length, e = i.split("."); if (r <= 4) { if (!$.isNumeric(i)) return R.val(A), !1; if (4 == r) { if (!(i >= 2001 && i <= 2257)) return R.val(""), !1; R.val(i + ".") } } if (5 == r) { var t = i.split(""); if ("." != t[4]) return R.val(A), !1; if (8 == r && "." != t[7]) return R.val(A), !1 } if (6 == r) { var a = parseInt(e[1]); if (!$.isNumeric(a)) return void R.val(A); 0 == a || 1 == a || (R.val(A), r -= 1) } if (7 == r) { if (e.length > 2) return R.val(A), !1; a = parseInt(e[1]); if (!$.isNumeric(a)) return R.val(A), !1; if (!(a > 0 && a <= 12)) return R.val(A), r -= 1, !1 } else if (r > 7) return void R.val(A); A = R.val() }), $("form").on("blur", ".nepaliMonth", function (A) { var P = $(this).val().split("."); if (2 != P.length) return $(this).val(""), !1; var R = parseInt(P[0]), i = parseInt(P[1]); $.isNumeric(R) && $.isNumeric(i) ? (R >= 2001 && R <= 2257 || ($this.val(""), $(this).focus()), i > 0 && i < 13 || $this.val("")) : $(this).val("") }), $("form").on("blur", ".nepaliDate", function (R) { var i = $(this).val().split("."); if (3 != i.length) return $(this).val(""), !1; var r = parseInt(i[0]), e = parseInt(i[1]), t = parseInt(i[2]), a = P[r][e]; $.isNumeric(r) && $.isNumeric(e) && $.isNumeric(t) ? (r >= 2001 && r <= 2257 || ($this.val(""), $(this).focus()), e > 0 && e < 13 || $this.val(""), t > 0 && t <= a ? (1 == e.toString().length && (e = "0" + e), 1 == t.toString().length && (t = "0" + t, $(this).val(r + "." + e + "." + t))) : $(this).val("")) : $(this).val(""), A = "" }), $("form").on("keyup", ".nepaliDate", function (R) { if (8 == R.keyCode) return !1; R.keyCode; var i = $(this), r = i.val(), e = r.length, t = r.split("."); if (e <= 4) { if (!$.isNumeric(r)) return i.val(A), !1; if (4 == e) { if (!(r >= 2001 && r <= 2257)) return i.val(""), !1; i.val(r + ".") } } if (5 == e || 8 == e) { var a = r.split(""); if ("." != a[4]) return i.val(A), !1; if (8 == e && "." != a[7]) return i.val(A), !1 } if (6 == e) { var l = parseInt(t[1]); if (!$.isNumeric(l)) return void i.val(A); 0 == l || 1 == l || (i.val(A), e -= 1) } if (7 == e) { if (t.length > 2) return i.val(A), !1; l = parseInt(t[1]); if (!$.isNumeric(l)) return i.val(A), !1; if (!(l > 0 && l <= 12)) return i.val(A), e -= 1, !1; i.val(r + ".") } if (9 == e) { var n = parseInt(t[2]); if (t.length > 3) return i.val(A), !1; $.isNumeric(n) || i.val(A), n >= 0 && n < 4 || (i.val(A), e -= 1) } else if (10 == e) { if (t.length > 3) return i.val(A), !1; l = parseInt(t[1]); var v = parseInt(t[0]); n = parseInt(t[2]); if (!$.isNumeric(n)) return i.val(A), !1; var s = P[v][l]; t[2] > 0 && t[2] <= s || (i.val(A), e -= 1) } else if (e > 10) return void i.val(A); A = i.val() }); var P = { 2067: ["14 - APR - 10", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2001: ["13 - APR - 44", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2002: ["13 - APR - 45", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2003: ["13 - APR - 46", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2004: ["14 - APR - 47", 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2005: ["13 - APR - 48", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2006: ["13 - APR - 49", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2007: ["13 - APR - 50", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2008: ["14 - APR - 51", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31], 2009: ["13 - APR - 52", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2010: ["13 - APR - 53", 31, 31, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2011: ["13 - APR - 54", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2012: ["14 - APR - 55", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30], 2013: ["13 - APR - 56", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2014: ["13 - APR - 57", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2015: ["13 - APR - 58", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2016: ["14 - APR - 59", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30], 2017: ["13 - APR - 60", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2018: ["13 - APR - 61", 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2019: ["13 - APR - 62", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2020: ["14 - APR - 63", 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30], 2021: ["13 - APR - 64", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2022: ["13 - APR - 65", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30], 2023: ["13 - APR - 66", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2024: ["14 - APR - 67", 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30], 2025: ["13 - APR - 68", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2026: ["13 - APR - 69", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2027: ["14 - APR - 70", 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2028: ["14 - APR - 71", 31, 31, 31, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2029: ["13 - APR - 72", 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30], 2030: ["13 - APR - 73", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2031: ["14 - APR - 74", 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2032: ["14 - APR - 75", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2033: ["13 - APR - 76", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2034: ["13 - APR - 77", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2035: ["14 - APR - 78", 30, 32, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31], 2036: ["14 - APR - 79", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2037: ["13 - APR - 80", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2038: ["13 - APR - 81", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2039: ["14 - APR - 82", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30], 2040: ["14 - APR - 83", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2041: ["13 - APR - 84", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2042: ["13 - APR - 85", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2043: ["14 - APR - 86", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30], 2044: ["14 - APR - 87", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2045: ["13 - APR - 88", 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2046: ["13 - APR - 89", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2047: ["14 - APR - 90", 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30], 2048: ["14 - APR - 91", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2049: ["13 - APR - 92", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30], 2050: ["13 - APR - 93", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2051: ["14 - APR - 94", 31, 31, 32, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2052: ["14 - APR - 95", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2053: ["13 - APR - 96", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2054: ["13 - APR - 97", 31, 31, 32, 32, 31, 30, 30, 30, 29, 30, 30, 31], 2055: ["14 - APR - 98", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2056: ["14 - APR - 99", 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30], 2057: ["13 - APR - 00", 31, 32, 32, 32, 31, 31, 30, 30, 30, 29, 30, 31], 2058: ["14 - APR - 01", 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2060: ["14 - APR - 03", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2061: ["13 - APR - 04", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2059: ["14 - APR - 02", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2062: ["14 - APR - 05", 31, 31, 31, 32, 31, 31, 29, 30, 29, 30, 29, 31], 2063: ["14 - APR - 06", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2064: ["14 - APR - 07", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2065: ["13 - APR - 08", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2066: ["14 - APR - 09", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31], 2068: ["14 - APR - 11", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2258: ["17 - APR - 01", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2259: ["18 - APR - 02", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31], 2260: ["18 - APR - 03", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2261: ["17 - APR - 04", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2262: ["17 - APR - 05", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2263: ["18 - APR - 06", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30], 2264: ["18 - APR - 07", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2265: ["17 - APR - 08", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2266: ["17 - APR - 09", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2267: ["18 - APR - 10", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30], 2268: ["18 - APR - 11", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2269: ["17 - APR - 12", 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2270: ["17 - APR - 13", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2271: ["18 - APR - 14", 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30], 2272: ["18 - APR - 15", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2273: ["17 - APR - 16", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30], 2274: ["17 - APR - 17", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2275: ["18 - APR - 18", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2276: ["18 - APR - 19", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2277: ["17 - APR - 20", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2278: ["18 - APR - 21", 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2279: ["18 - APR - 22", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2280: ["18 - APR - 23", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2281: ["17 - APR - 24", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2282: ["18 - APR - 25", 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2283: ["18 - APR - 26", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2284: ["18 - APR - 27", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2285: ["17 - APR - 28", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2286: ["18 - APR - 29", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31], 2287: ["18 - APR - 30", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2288: ["18 - APR - 31", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2289: ["17 - APR - 32", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2290: ["18 - APR - 33", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30], 2291: ["18 - APR - 34", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2292: ["18 - APR - 35", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2293: ["17 - APR - 36", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2294: ["18 - APR - 37", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30], 2295: ["18 - APR - 38", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2296: ["18 - APR - 39", 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2297: ["17 - APR - 40", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2298: ["18 - APR - 41", 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30], 2299: ["18 - APR - 42", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2300: ["18 - APR - 43", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30], 2301: ["17 - APR - 44", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2302: ["18 - APR - 45", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2303: ["18 - APR - 46", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2304: ["18 - APR - 47", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2305: ["18 - APR - 48", 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2306: ["18 - APR - 49", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2307: ["18 - APR - 50", 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30], 2308: ["18 - APR - 51", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2309: ["18 - APR - 52", 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2082: ["14 - APR - 25", 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30], 1990: ["13 - APR - 33", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 1991: ["13 - APR - 34", 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30], 1992: ["13 - APR - 35", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 1993: ["13 - APR - 36", 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30], 1994: ["13 - APR - 37", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 1995: ["13 - APR - 38", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30], 1996: ["13 - APR - 39", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 1997: ["13 - APR - 40", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 1998: ["13 - APR - 41", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 1999: ["13 - APR - 42", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2000: ["14 - APR - 43", 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2069: ["13 - APR - 12", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2070: ["14 - APR - 13", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30], 2071: ["14 - APR - 14", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2072: ["14 - APR - 15", 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2073: ["13 - APR - 16", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2074: ["14 - APR - 17", 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30], 2075: ["14 - APR - 18", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2076: ["14 - APR - 19", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30], 2077: ["13 - APR - 20", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2078: ["14 - APR - 21", 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30], 2079: ["14 - APR - 22", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2080: ["14 - APR - 23", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30], 2081: ["13 - APR - 24", 31, 31, 32, 32, 31, 30, 30, 30, 29, 30, 30, 30], 2083: ["14 - APR - 26", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2084: ["14 - APR - 27", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2085: ["14 - APR - 28", 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2086: ["14 - APR - 29", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2087: ["14 - APR - 30", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2088: ["14 - APR - 31", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2089: ["14 - APR - 32", 30, 32, 31, 32, 31, 31, 29, 30, 29, 30, 29, 31], 2090: ["14 - APR - 33", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2091: ["14 - APR - 34", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2092: ["14 - APR - 35", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2093: ["14 - APR - 36", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31], 2094: ["14 - APR - 37", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2095: ["14 - APR - 38", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2096: ["14 - APR - 39", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2097: ["14 - APR - 40", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30], 2098: ["14 - APR - 41", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2099: ["14 - APR - 42", 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2100: ["14 - APR - 43", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2101: ["14 - APR - 44", 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30], 2102: ["14 - APR - 45", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2103: ["14 - APR - 46", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30], 2104: ["14 - APR - 47", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2105: ["14 - APR - 48", 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30], 2106: ["14 - APR - 49", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2107: ["14 - APR - 50", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30], 2108: ["14 - APR - 51", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2109: ["14 - APR - 52", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2110: ["14 - APR - 53", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2111: ["14 - APR - 54", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2112: ["15 - APR - 55", 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2113: ["14 - APR - 56", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2114: ["14 - APR - 57", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2115: ["14 - APR - 58", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2116: ["15 - APR - 59", 30, 32, 31, 32, 31, 31, 29, 30, 29, 30, 29, 31], 2117: ["14 - APR - 60", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2118: ["14 - APR - 61", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2119: ["14 - APR - 62", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2120: ["15 - APR - 63", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31], 2121: ["14 - APR - 64", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2122: ["14 - APR - 65", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2123: ["14 - APR - 66", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2124: ["15 - APR - 67", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30], 2125: ["14 - APR - 68", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2126: ["14 - APR - 69", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2127: ["14 - APR - 70", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2128: ["15 - APR - 71", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30], 2129: ["14 - APR - 72", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2130: ["14 - APR - 73", 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2131: ["14 - APR - 74", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2132: ["15 - APR - 75", 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30], 2133: ["14 - APR - 76", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2134: ["14 - APR - 77", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30], 2135: ["14 - APR - 78", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2136: ["15 - APR - 79", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2137: ["14 - APR - 80", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2138: ["14 - APR - 81", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2139: ["15 - APR - 82", 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2140: ["15 - APR - 83", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2141: ["14 - APR - 84", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2142: ["14 - APR - 85", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2143: ["15 - APR - 86", 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2144: ["15 - APR - 87", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2145: ["14 - APR - 88", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2146: ["14 - APR - 89", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2147: ["15 - APR - 90", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31], 2148: ["15 - APR - 91", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2149: ["14 - APR - 92", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2150: ["14 - APR - 93", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2151: ["15 - APR - 94", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30], 2152: ["15 - APR - 95", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2153: ["14 - APR - 96", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2154: ["14 - APR - 97", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2155: ["15 - APR - 98", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30], 2156: ["15 - APR - 99", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 29, 31], 2157: ["15 - APR - 00", 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2158: ["15 - APR - 01", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2159: ["16 - APR - 02", 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30], 2160: ["16 - APR - 03", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2161: ["15 - APR - 04", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30], 2162: ["15 - APR - 05", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2163: ["16 - APR - 06", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2164: ["16 - APR - 07", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2165: ["15 - APR - 08", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2166: ["16 - APR - 09", 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2167: ["16 - APR - 10", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2168: ["16 - APR - 11", 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30], 2169: ["15 - APR - 12", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2170: ["16 - APR - 13", 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2171: ["16 - APR - 14", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2172: ["16 - APR - 15", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2173: ["15 - APR - 16", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2174: ["16 - APR - 17", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31], 2175: ["16 - APR - 18", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2176: ["16 - APR - 19", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2177: ["15 - APR - 20", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2178: ["16 - APR - 21", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30], 2179: ["16 - APR - 22", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2180: ["16 - APR - 23", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2181: ["15 - APR - 24", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2182: ["16 - APR - 25", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30], 2183: ["16 - APR - 26", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2184: ["16 - APR - 27", 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2185: ["15 - APR - 28", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2186: ["16 - APR - 29", 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30], 2187: ["16 - APR - 30", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2188: ["16 - APR - 31", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30], 2189: ["15 - APR - 32", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2190: ["16 - APR - 33", 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30], 2191: ["16 - APR - 34", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2192: ["16 - APR - 35", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30], 2193: ["15 - APR - 36", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2194: ["16 - APR - 37", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2195: ["16 - APR - 38", 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30], 2196: ["16 - APR - 39", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2197: ["16 - APR - 40", 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2198: ["16 - APR - 41", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2199: ["16 - APR - 42", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2200: ["16 - APR - 43", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2201: ["16 - APR - 44", 30, 32, 31, 32, 31, 31, 29, 30, 29, 30, 29, 31], 2202: ["16 - APR - 45", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2203: ["16 - APR - 46", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2204: ["16 - APR - 47", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2205: ["16 - APR - 48", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31], 2206: ["16 - APR - 49", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2207: ["16 - APR - 50", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2208: ["16 - APR - 51", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2209: ["16 - APR - 52", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30], 2210: ["16 - APR - 53", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2211: ["16 - APR - 54", 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2212: ["16 - APR - 55", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2213: ["16 - APR - 56", 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30], 2214: ["16 - APR - 57", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2215: ["16 - APR - 58", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30], 2216: ["16 - APR - 59", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2217: ["16 - APR - 60", 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30], 2218: ["16 - APR - 61", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2219: ["16 - APR - 62", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30], 2220: ["16 - APR - 63", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2221: ["16 - APR - 64", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2222: ["16 - APR - 65", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2223: ["16 - APR - 66", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2224: ["17 - APR - 67", 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2225: ["16 - APR - 68", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2226: ["16 - APR - 69", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2227: ["16 - APR - 70", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2228: ["17 - APR - 71", 30, 32, 31, 32, 31, 31, 29, 30, 29, 30, 29, 31], 2229: ["16 - APR - 72", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2230: ["16 - APR - 73", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2231: ["16 - APR - 74", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2232: ["17 - APR - 75", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31], 2233: ["16 - APR - 76", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2234: ["16 - APR - 77", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2235: ["16 - APR - 78", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2236: ["17 - APR - 79", 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30], 2237: ["16 - APR - 80", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2238: ["16 - APR - 81", 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2239: ["16 - APR - 82", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2240: ["17 - APR - 83", 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30], 2241: ["16 - APR - 84", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2242: ["16 - APR - 85", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30], 2243: ["16 - APR - 86", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2244: ["17 - APR - 87", 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30], 2245: ["16 - APR - 88", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2246: ["16 - APR - 89", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30], 2247: ["16 - APR - 90", 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2248: ["17 - APR - 91", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2249: ["16 - APR - 92", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2250: ["16 - APR - 93", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2251: ["17 - APR - 94", 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31], 2252: ["17 - APR - 95", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30], 2253: ["16 - APR - 96", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30], 2254: ["16 - APR - 97", 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31], 2255: ["17 - APR - 98", 30, 32, 31, 32, 31, 31, 29, 30, 29, 30, 29, 31], 2256: ["17 - APR - 99", 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 29, 31], 2257: ["17 - APR - 00", 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30]} });