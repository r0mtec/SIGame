﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.PackClass
{
    public class QuestionClass
    {
        public String? question {  get; set; }

        public int? price { get; set; }

        public List<String> varinats = new List<String>();

        public List<String>? getVariantsAnswer()
        {
            if (varinats.Count == 0)
            {
                return null;
            }
            return varinats;
        }

        public String? answer { get; set; }

        public QuestionsType type;
        public bool isUsed = false;
        public void initQuestion (StreamReader fileStream)
        {

            String buf = "";
            
            question = "";
            answer = "";
            if (fileStream.ReadLine().Contains("PRICE")) {
                try
                {
                    price = int.Parse(fileStream.ReadLine());
                }
                catch
                {
                    price = 100;
                }
            }
            buf = new string(fileStream.ReadLine());
            if (buf.Contains("QUESTION PHOTO"))
            {
                type = QuestionsType.photo;
                buf = new string(fileStream.ReadLine());
                while (!buf.Contains("QUESTION PHOTO END"))
                {
                    question += buf;
                    buf = new string(fileStream.ReadLine());
                }
            }
            else if (buf.Contains("QUESTION AUDIO"))
            {
                type = QuestionsType.audio;
                buf = new string(fileStream.ReadLine());
                while (!buf.Contains("QUESTION AUDIO END"))
                {
                    question += buf;
                    buf = new string(fileStream.ReadLine());
                }
            }
            else if (buf.Contains("QUESTION"))
            {
                type = QuestionsType.text;
                buf = new string(fileStream.ReadLine());
                question += buf;
                buf = new string(fileStream.ReadLine());
                while (!buf.Contains("QUESTION END"))
                {
                    varinats.Add(buf);
                    type = QuestionsType.selection;
                    buf = new string(fileStream.ReadLine());
                }
            }
            

            if (fileStream.ReadLine().Contains("ANSWER"))
            {
               
                buf = new string(fileStream.ReadLine());
                while (!buf.Contains("ANSWER END"))
                {
                    answer += buf;
                    buf = new string(fileStream.ReadLine());
                }
            }

        }

    }
}
