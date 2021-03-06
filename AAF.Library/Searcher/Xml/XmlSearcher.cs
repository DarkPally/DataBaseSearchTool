﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using System.IO;
using System.Xml;

namespace AAF.Library.Searcher
{
    public class XmlSearcher
    {
        public List<XmlSearchResultItem> KeyValueItems=new List<XmlSearchResultItem>();
        public void Init(string dbPath)
        {
            
            try
            {
                var xml = new XmlDocument();
                xml.Load(dbPath);
                var fileName = Path.GetFileName(dbPath);
                var node = xml.SelectSingleNode("map");
                if (node != null)
                {

                    foreach (XmlNode it in node.ChildNodes)
                    {
                        var tItem = new XmlSearchResultItem()
                        {
                            FullPath = dbPath,
                            FileName = fileName,
                            ElementName = it.Attributes[0].Value,
                            ElementType = it.LocalName,
                            DataPath = it.Attributes[0].Value,
                            
                        };
                        if (it.Attributes.Count > 1)
                        {
                            tItem.ElementValue = it.Attributes[1].Value;
                        }
                        else
                        {
                            tItem.ElementValue = it.InnerText;
                        }
                        tItem.Data = tItem.ElementValue;
                        KeyValueItems.Add(tItem);
                    }
                }
            }
            catch
            {

            }
        }
        public DataSearchResult SearchStr(string keyStr)
        {
            var t = new DataSearchResult()
            {
                Items = KeyValueItems.AsParallel().Where(
                c => c.ElementValue != null && c.ElementValue.Contains(keyStr)).Select(c => c as DataSearchResultItem).ToList()
            };
            return t;
        }
    }
}
