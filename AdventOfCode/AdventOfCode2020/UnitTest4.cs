using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class UnitTest4
    {
        private List<string> _lstLines;
        private string[] _lines;

        [SetUp]
        public void Setup()
        {
            _lines = File.ReadAllLines(@"D:\Proyectos\proyectos-personales\adventofcode\AdventOfCode\AdventOfCode2020\Resources\input4.txt");
            //_lines = new string[] { "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
            //                        "byr:1937 iyr:2017 cid:147 hgt:183cm",
            //                        "",
            //                        "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884",
            //                        "hcl:#cfa07d byr:1929",
            //                        "",
            //                        "hcl:#ae17e1 iyr:2013",
            //                        "eyr:2024",
            //                        "ecl:brn pid:760753108 byr:1931",
            //                        "hgt:179cm",
            //                        "",
            //                        "hcl:#cfa07d eyr:2025 pid:166559648",
            //                        "iyr:2011 ecl:brn hgt:59in"
            //};
            //_lines = new string[] { "pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980 hcl:#623a2f",
            //                        "",
            //                        "eyr:2029 ecl:blu cid:129 byr:1989 iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm",
            //                        "",
            //                        "hcl:#888785 hgt:164cm byr:2001 iyr:2015 cid:88 pid:545766238 ecl:hzl eyr:2022",
            //                        "",
            //                        "iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719"};

            _lstLines = _lines.OfType<string>().ToList();
        }

        [Test]
        public void Test1()
        {
            int result = 0;
            string concatLine = string.Empty;
            string[] required = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };            

            foreach (var line in _lines)
            {
                if (line.Equals(string.Empty))
                {
                    if (Validations(concatLine, required)) result++;

                    concatLine = string.Empty;
                }
                concatLine += " " + line.Trim();
            }

            if (Validations(concatLine, required)) result++;

            Console.WriteLine("Result: " + result);
            Assert.IsNotNull(result.ToString());
        }

        private bool Validations(string validate, string[] required)
        {
            foreach (string rule in required)
            {
                if (!validate.Contains(rule))
                    return false;
            }
            return true;
        }

        [Test]
        public void Test2()
        {
            int result = 0;
            string concatLine = string.Empty;            
            IDictionary<string, string[]> requirements = new Dictionary<string, string[]>();
            requirements.Add("byr", new string[] { "4", "1920", "2002" });
            requirements.Add("iyr", new string[] { "4", "2010", "2020" });
            requirements.Add("eyr", new string[] { "4", "2020", "2030" });
            requirements.Add("hgt", new string[] { "cm", "150", "193", "in", "59", "76" });
            requirements.Add("hcl", new string[] { "#", "6", "0-9", "a-f" });
            requirements.Add("ecl", new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" });
            requirements.Add("pid", new string[] { "0-9" });

            foreach (var line in _lines)
            {
                if (line.Equals(string.Empty))
                {
                    if (Validations(concatLine, requirements)) result++;

                    concatLine = string.Empty;
                }
                concatLine += " " + line.Trim();
            }

            if (Validations(concatLine, requirements)) result++;

            Console.WriteLine("Result: " + result);
            Assert.IsNotNull(result.ToString());
        }

        private bool Validations(string validate, IDictionary<string, string[]> required)
        {
            foreach (KeyValuePair<string, string[]> rule in required)
            {
                if (!validate.Contains(rule.Key))
                    return false;
            }

            foreach (string field in validate.Trim().Split(' '))
            {
                string[] array = field.Trim().Split(':');
                string value = array[1].ToString();
                switch (array[0].ToString())
                {
                    case "byr":
                        if (value.Length != 4)
                            return false;
                        else if (int.Parse(value) < 1920 || int.Parse(value) > 2002)
                            return false;
                        break;
                    case "iyr":
                        if (value.Length != 4)
                            return false;
                        else if (int.Parse(value) < 2010 || int.Parse(value) > 2020)
                            return false;
                        break;
                    case "eyr":
                        if (value.Length != 4)
                            return false;
                        else if (int.Parse(value) < 2020 || int.Parse(value) > 2030)
                            return false;
                        break;
                    case "hgt":

                        if (value.Contains("cm"))
                        {
                            value = value.Replace("cm", "");
                            if ((int.Parse(value) < 150 || int.Parse(value) > 193))
                                return false;
                        }
                            
                        else if (value.Contains("in"))
                        {
                            value = value.Replace("in", "");
                            if ((int.Parse(value) < 59 || int.Parse(value) > 76))
                                return false;
                        }       
                        else return false;
                        break;
                    case "hcl":
                        if (!value[0].Equals('#'))
                            return false;                        
                        foreach (var item in "ghijklmnopqrstuvwxyz")
                            if (value.Contains(item)) return false;
                        break;
                    case "ecl":
                        string[] search = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                        if (!search.Contains(value))
                            return false;
                        break;
                    case "pid":
                        if (value.Length != 9)
                            return false;
                        break;
                    default:
                        break;
                }
            }

            return true;
        }
    }
}
