using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Net;
using System.Collections;

/*
So if they ever decide to change how the page is laid out, this won't work.  Hopefully that's a slim chance.
However, there's a reasonable chance that they'll change numbering when it comes to the *81's and the 950's.  
I made an exception for those in the code- if you search for "81" or "950" you'll find it.  Essentially it
looks at the previous class number to decide if it needs to keep both the old class number and name, or just
the number.  Have fun with that one.

TBA Classes don't print.  If you want to display them, write an additional piece into the sorting/printing
function that sort through for TBA's and prints them up.
*/


namespace FacultyLocator
{
    class classinstance
    {
        public string classnumber;
        public string classname;
        public string section;
        public string hours;
        public string time;
        public string location;
        public string instructor;
        public string code;
    }

    class Program
    {

        static void printbytime(List<classinstance> classes) {
            int i = 0;

            List<classinstance> monday = new List<classinstance>();
            List<classinstance> tuesday = new List<classinstance>();
            List<classinstance> wednesday = new List<classinstance>();
            List<classinstance> thursday = new List<classinstance>();
            List<classinstance> friday = new List<classinstance>();

            Console.Write(Environment.NewLine);
            Console.WriteLine("Sorting and Printing to File.");

            while (i < classes.Count)
            {
                if (classes[i].time != "TO BE ARRANGED" && !classes[i].classnumber.Contains("L"))
                {
                    if (classes[i].time.Contains("M"))
                        if (!classes[i].time.Contains("PM"))
                            monday.Add(classes[i]);
                        else
                        {
                            string tempstr = classes[i].time;
                            int tempint = tempstr.IndexOf("M");
                            tempstr = tempstr.Substring(tempint);
                            if (tempstr.Contains("M"))
                                monday.Add(classes[i]);
                        }
                    if (classes[i].time.Contains("T"))
                        if (!classes[i].time.Contains("TH"))
                            tuesday.Add(classes[i]);
                        else
                        {
                            string tempstr = classes[i].time;
                            int tempint = tempstr.IndexOf("T");
                            tempstr = tempstr.Substring(tempint);
                            if (tempstr.Contains("T"))
                                tuesday.Add(classes[i]);
                        }
                    if (classes[i].time.Contains("W"))
                        wednesday.Add(classes[i]);
                    if (classes[i].time.Contains("TH"))
                        thursday.Add(classes[i]);
                    if (classes[i].time.Contains("F"))
                        friday.Add(classes[i]);
                }
                i++;
            }

            Boolean found = false;
            int time = 5; //start at 5 am
            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", "----------------------------MONDAY----------------------------");
            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", Environment.NewLine + Environment.NewLine);

            while (time != 1) //starts at 5 am, end before 1 pm
            {
                i = 0;
                while (i < monday.Count){
                    if (!monday[i].time.Contains("PM")) //during the morning
                    {
                        if (monday[i].time.StartsWith(Convert.ToString(time))) //find things starting this hour
                        {
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", monday[i].classnumber + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", monday[i].classname + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", monday[i].section + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", monday[i].hours + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", monday[i].time + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", monday[i].location + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", monday[i].instructor + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", monday[i].code + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", Environment.NewLine);
                            monday.RemoveAt(i);
                            found = true;
                        }
                    }
                    if (found == false)
                        i++;
                    found = false;
                }
                time++;
                if (time > 12)
                    time = 1;
            }
            
            while (time != 12) //starts at 1 pm, ends before 12 pm
            {
                i = 0;
                while (i < monday.Count)
                {
                    if (monday[i].time.StartsWith(Convert.ToString(time))) //find things starting this hour
                    {
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", monday[i].classnumber + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", monday[i].classname + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", monday[i].section + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", monday[i].hours + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", monday[i].time + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", monday[i].location + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", monday[i].instructor + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", monday[i].code + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", Environment.NewLine);
                        monday.RemoveAt(i);
                        found = true;
                    }
                    if (found == false)
                        i++;
                    found = false;
                }
                time++;
                if (time > 12)
                    time = 1;
            }

            found = false;
            time = 5; //start at 5 am
            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", "----------------------------TUESDAY----------------------------");
            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", Environment.NewLine + Environment.NewLine);

            while (time != 1) //starts at 5 am, end before 1 pm
            {
                i = 0;
                while (i < tuesday.Count)
                {
                    if (!tuesday[i].time.Contains("PM")) //during the morning
                    {
                        if (tuesday[i].time.StartsWith(Convert.ToString(time))) //find things starting this hour
                        {
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", tuesday[i].classnumber + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", tuesday[i].classname + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", tuesday[i].section + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", tuesday[i].hours + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", tuesday[i].time + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", tuesday[i].location + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", tuesday[i].instructor + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", tuesday[i].code + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", Environment.NewLine);
                            tuesday.RemoveAt(i);
                            found = true;
                        }
                    }
                    if (found == false)
                        i++;
                    found = false;
                }
                time++;
                if (time > 12)
                    time = 1;
            }

            while (time != 12) //starts at 1 pm, ends before 12 pm
            {
                i = 0;
                while (i < tuesday.Count)
                {
                    if (tuesday[i].time.StartsWith(Convert.ToString(time))) //find things starting this hour
                    {
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", tuesday[i].classnumber + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", tuesday[i].classname + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", tuesday[i].section + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", tuesday[i].hours + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", tuesday[i].time + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", tuesday[i].location + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", tuesday[i].instructor + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", tuesday[i].code + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", Environment.NewLine);
                        tuesday.RemoveAt(i);
                        found = true;
                    }
                    if (found == false)
                        i++;
                    found = false;
                }
                time++;
                if (time > 12)
                    time = 1;
            }
            
            found = false;
            time = 5; //start at 5 am
            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", "----------------------------WEDNESDAY----------------------------");
            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", Environment.NewLine + Environment.NewLine);

            while (time != 1) //starts at 5 am, end before 1 pm
            {
                i = 0;
                while (i < wednesday.Count)
                {
                    if (!wednesday[i].time.Contains("PM")) //during the morning
                    {
                        if (wednesday[i].time.StartsWith(Convert.ToString(time))) //find things starting this hour
                        {
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", wednesday[i].classnumber + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", wednesday[i].classname + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", wednesday[i].section + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", wednesday[i].hours + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", wednesday[i].time + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", wednesday[i].location + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", wednesday[i].instructor + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", wednesday[i].code + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", Environment.NewLine);
                            wednesday.RemoveAt(i);
                            found = true;
                        }
                    }
                    if (found == false)
                        i++;
                    found = false;
                }
                time++;
                if (time > 12)
                    time = 1;
            }

            while (time != 12) //starts at 1 pm, ends before 12 pm
            {
                i = 0;
                while (i < wednesday.Count)
                {
                    if (wednesday[i].time.StartsWith(Convert.ToString(time))) //find things starting this hour
                    {
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", wednesday[i].classnumber + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", wednesday[i].classname + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", wednesday[i].section + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", wednesday[i].hours + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", wednesday[i].time + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", wednesday[i].location + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", wednesday[i].instructor + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", wednesday[i].code + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", Environment.NewLine);
                        wednesday.RemoveAt(i);
                        found = true;
                    }
                    if (found == false)
                        i++;
                    found = false;
                }
                time++;
                if (time > 12)
                    time = 1;
            }
            
            found = false;
            time = 5; //start at 5 am
            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", "----------------------------THURSDAY----------------------------");
            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", Environment.NewLine + Environment.NewLine);

            while (time != 1) //starts at 5 am, end before 1 pm
            {
                i = 0;
                while (i < thursday.Count)
                {
                    if (!thursday[i].time.Contains("PM")) //during the morning
                    {
                        if (thursday[i].time.StartsWith(Convert.ToString(time))) //find things starting this hour
                        {
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", thursday[i].classnumber + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", thursday[i].classname + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", thursday[i].section + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", thursday[i].hours + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", thursday[i].time + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", thursday[i].location + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", thursday[i].instructor + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", thursday[i].code + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", Environment.NewLine);
                            thursday.RemoveAt(i);
                            found = true;
                        }
                    }
                    if (found == false)
                        i++;
                    found = false;
                }
                time++;
                if (time > 12)
                    time = 1;
            }

            while (time != 12) //starts at 1 pm, ends before 12 pm
            {
                i = 0;
                while (i < thursday.Count)
                {
                    if (thursday[i].time.StartsWith(Convert.ToString(time))) //find things starting this hour
                    {
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", thursday[i].classnumber + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", thursday[i].classname + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", thursday[i].section + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", thursday[i].hours + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", thursday[i].time + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", thursday[i].location + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", thursday[i].instructor + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", thursday[i].code + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", Environment.NewLine);
                        thursday.RemoveAt(i);
                        found = true;
                    }
                    if (found == false)
                        i++;
                    found = false;
                }
                time++;
                if (time > 12)
                    time = 1;
            }
            
            found = false;
            time = 5; //start at 5 am
            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", "----------------------------FRIDAY----------------------------");
            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", Environment.NewLine + Environment.NewLine);

            while (time != 1) //starts at 5 am, end before 1 pm
            {
                i = 0;
                while (i < friday.Count)
                {
                    if (!friday[i].time.Contains("PM")) //during the morning
                    {
                        if (friday[i].time.StartsWith(Convert.ToString(time))) //find things starting this hour
                        {
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", friday[i].classnumber + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", friday[i].classname + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", friday[i].section + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", friday[i].hours + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", friday[i].time + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", friday[i].location + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", friday[i].instructor + Environment.NewLine);
                            //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", friday[i].code + Environment.NewLine);
                            System.IO.File.AppendAllText(@"C:\socoutput\test.txt", Environment.NewLine);
                            friday.RemoveAt(i);
                            found = true;
                        }
                    }
                    if (found == false)
                        i++;
                    found = false;
                }
                time++;
                if (time > 12)
                    time = 1;
            }

            while (time != 12) //starts at 1 pm, ends before 12 pm
            {
                i = 0;
                while (i < friday.Count)
                {
                    if (friday[i].time.StartsWith(Convert.ToString(time))) //find things starting this hour
                    {
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", friday[i].classnumber + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", friday[i].classname + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", friday[i].section + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", friday[i].hours + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", friday[i].time + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", friday[i].location + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", friday[i].instructor + Environment.NewLine);
                        //System.IO.File.AppendAllText(@"C:\socoutput\test.txt", friday[i].code + Environment.NewLine);
                        System.IO.File.AppendAllText(@"C:\socoutput\test.txt", Environment.NewLine);
                        friday.RemoveAt(i);
                        found = true;
                    }
                    if (found == false)
                        i++;
                    found = false;
                }
                time++;
                if (time > 12)
                    time = 1;
            }
        }

        void printbyinstructor(classinstance[] classes) {
            //unfinished
        }

        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            byte[] buf = new byte[8192];

            Console.WriteLine("Retrieving Webpage.");

            HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://soc.clemson.edu/CP_SC.FALL.htm");
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            Stream sourcestream = response.GetResponseStream();
            
            string temp = null;
            int count = 0;

            do
            {
                count = sourcestream.Read(buf, 0, buf.Length);

                if (count != 0)
                {
                    temp = Encoding.ASCII.GetString(buf, 0, count);
                    sb.Append(temp);
                }

            } while (count > 0);

            System.Console.WriteLine("Recieved Webpage, now parsing.");

            string source = sb.ToString();
            char[] delimiterChars = {'>'};
            int progress = 0;
            int timer = 10000;
            Boolean stop = false;
            List<classinstance> classes = new List<classinstance>();
            int currentclass = -1;
            int number = 1;
            Boolean lab = false;
            Boolean gotcode = true;

            do {
            progress = source.IndexOf("<font size=2>", progress); // find the first opening font tag

            if (progress > timer) //displays progress
            {
                System.Console.Write(".");
                timer += 10000;
            }

            if (progress != -1 && progress != 0) // if found opening font tag
            {
                int progress2 = source.IndexOf("</font>", progress);
                temp = source.Substring(progress + 13, progress2 - progress - 13); //pull everything out of font tag
                if (temp.StartsWith("<i>") || temp == "</i>" || temp == "&nbsp;" || temp.Contains("Javascript") ||
                    temp == "<td " || temp == "<td>" || temp == "</font>" || temp == "&nbsp;</font>")
                {
                    temp = "";
                }
                else if (temp == "")
                    temp = " ";
                else if (temp.StartsWith("<a href=")) //remove formatting and links
                {
                    int href1 = temp.IndexOf(">", 0);
                    int href2 = temp.IndexOf("</a>", href1);
                    temp = temp.Substring(href1 + 1, href2 - href1 - 1);
                }

                /*if (gotcode == true && ((temp.StartsWith("CP SC") && temp.Contains("L")) || (temp.StartsWith(""))))
                    lab = true;
                else
                    lab = false;*/

                if (temp != "")
                {
                    if (gotcode == true)
                    {
                        currentclass = classes.Count;
                        classes.Add(new classinstance());

                        if (temp.StartsWith("CP SC"))
                        {
                            System.Console.Write(".");
                            gotcode = false;
                            number = 1;
                        }
                        else if (classes[currentclass - 1].classnumber.Contains("81") || classes[currentclass - 1].classnumber.Contains("950"))
                        {
                            classes[currentclass].classnumber = classes[currentclass - 1].classnumber;
                            number = 2;
                            gotcode = false;
                        }
                        else
                        {
                            classes[currentclass].classnumber = classes[currentclass - 1].classnumber;
                            classes[currentclass].classname = classes[currentclass - 1].classname;
                            number = 3;
                            gotcode = false;
                        }
                    }

                    if (number == 1)
                        classes[currentclass].classnumber = temp;
                    else if (number == 2)
                        classes[currentclass].classname = temp;
                    else if (number == 3)
                        classes[currentclass].section = temp;
                    else if (number == 4)
                        classes[currentclass].hours = temp;
                    else if (number == 5)
                        classes[currentclass].time = temp;
                    else if (number == 6)
                        classes[currentclass].location = temp;
                    else if (number == 7)
                        classes[currentclass].instructor = temp;
                    else if (number == 8)
                    {
                        classes[currentclass].code = temp;
                        gotcode = true;
                    }
                    number += 1;
                }
                progress = progress2;
            }
            else
                stop = true;
            } while (stop == false);

            printbytime(classes);
            Console.Write(Environment.NewLine);
            Console.WriteLine("Done, please press enter");
            Console.ReadLine();
        }
    }
}
