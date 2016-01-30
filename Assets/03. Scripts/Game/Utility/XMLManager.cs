﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using UnityEngine;

public class XMLManager
{
    private static XMLManager instance = new XMLManager();
    public static XMLManager Instance { get { return instance; } }

    XmlNodeList characterTable;
    XmlNodeList enemyTable;
    XmlNodeList stageTable;

    //DESC : 초기화
    public XMLManager()
    {
        characterTable = LoadXml("Character", "NewDataSet", "Sheet1");
        enemyTable = LoadXml("Enemy", "NewDataSet", "Sheet1");
        stageTable = LoadXml("Stage", "NewDataSet", "Sheet1");
    }

    public XmlNodeList LoadXml(string fileName, string dataset, string sheet)
    {
        string directory = "XML/" + fileName;
        string targetnode = dataset + "/" + sheet;

        TextAsset textAsset = Resources.Load(fileName) as TextAsset;
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml(textAsset.text);
        
        return xmldoc.SelectNodes(targetnode);
    }
   
    public CharacterInfo Load_CharacterData(int id)
    {
        CharacterInfo temp = new CharacterInfo();

        foreach(XmlNode node in characterTable)
        {
            if(id == int.Parse(node.SelectSingleNode("ID").InnerText))
            {
                temp.ID = id;
                temp.HP = int.Parse(node.SelectSingleNode("HP").InnerText);
                temp.AP = int.Parse(node.SelectSingleNode("AP").InnerText);
                temp.Name = node.SelectSingleNode("Name").InnerText;
                temp.Sac1 = int.Parse(node.SelectSingleNode("Sac1").InnerText);
                temp.Sac2 = int.Parse(node.SelectSingleNode("Sac2").InnerText);
                temp.Sac3 = int.Parse(node.SelectSingleNode("Sac3").InnerText);
                temp.Sac4 = int.Parse(node.SelectSingleNode("Sac4").InnerText);
                temp.Sac5 = int.Parse(node.SelectSingleNode("Sac5").InnerText);

                return temp;
            }
        }
        return null;
    }
    public CharacterInfo Load_CharacterData(int Sac2, int Sac3, int Sac4, int Sac5)
    {
        CharacterInfo temp = new CharacterInfo();

        foreach (XmlNode node in characterTable)
        {
            if(int.Parse(node.SelectSingleNode("Sac2").InnerText) == Sac2)
            {
                if(int.Parse(node.SelectSingleNode("Sac3").InnerText) == Sac3)
                {
                    if(int.Parse(node.SelectSingleNode("Sac4").InnerText) == Sac4)
                    {
                        if(int.Parse(node.SelectSingleNode("Sac5").InnerText) == Sac5)
                        {
                            temp.ID = int.Parse(node.SelectSingleNode("ID").InnerText);
                            temp.Name = node.SelectSingleNode("Name").InnerText;
                            temp.HP = int.Parse(node.SelectSingleNode("HP").InnerText);
                            temp.AP = int.Parse(node.SelectSingleNode("AP").InnerText);
                            temp.Sac1 = int.Parse(node.SelectSingleNode("Sac1").InnerText);
                            temp.Sac2 = int.Parse(node.SelectSingleNode("Sac2").InnerText);
                            temp.Sac3 = int.Parse(node.SelectSingleNode("Sac3").InnerText);
                            temp.Sac4 = int.Parse(node.SelectSingleNode("Sac4").InnerText);
                            temp.Sac5 = int.Parse(node.SelectSingleNode("Sac5").InnerText);

                            return temp;
                        }
                    }
                        
                }
            }
        }
        return null;
    }

    public EnemyInfo Load_EnemyData(int id)
    {
        EnemyInfo temp = new EnemyInfo();

        foreach(XmlNode node in enemyTable)
        {
            if(id == int.Parse(node.SelectSingleNode("ID").InnerText))
            {
                temp.ID = id;
                temp.Name = node.SelectSingleNode("Name").InnerText;
                temp.HP = int.Parse(node.SelectSingleNode("HP").InnerText);
                temp.AP = int.Parse(node.SelectSingleNode("AP").InnerText);

                return temp;
            }
        }
        return null;
    }
}

public class CharacterInfo
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int HP { get; set; }
    public int AP { get; set; }
    public int Sac1 { get; set; }
    public int Sac2 { get; set; }
    public int Sac3 { get; set; }
    public int Sac4 { get; set; }
    public int Sac5 { get; set; }
}

public class EnemyInfo
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int HP { get; set; }
    public int AP { get; set; }
}

