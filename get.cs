using System;
using System.Diagnostics;
using System.Collections.Generic;

class GetLogoffTime {
    public static void Main() {
        SortedDictionary<string, DateTime> sdict = new SortedDictionary<string, DateTime>();

        List<DateTime> l = LogoffTime();
        foreach(DateTime dt in l)
        {
            String date = dt.ToString("yyyy/MM/dd");
            if (!sdict.ContainsKey(date) || dt > sdict[date])
            {
                sdict[date] = dt;
            }
        }

        foreach (KeyValuePair<string, DateTime> kvp in sdict)
        {
            Console.WriteLine("{0} -> {1}", kvp.Key, kvp.Value.ToString("t"));
        }
    }

    public static List<DateTime> LogoffTime() {
        List<DateTime> ldt = new List<DateTime>();

        EventLog[] logs = EventLog.GetEventLogs();
        foreach (EventLog log in logs)
        {
            foreach (EventLogEntry entry in log.Entries)
            {
                if (entry.InstanceId != 551) { continue; }
                ldt.Add(entry.TimeGenerated);
            }
        }

        return ldt;
    }
}
