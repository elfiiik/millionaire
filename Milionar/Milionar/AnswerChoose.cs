using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Newtonsoft.Json;
namespace Milionar
{
    class AnswerChoose
    {
        public List<int> Answered = new List<int>();
        public List<Answers> Choose()
        {
            bool Choose = true;
            List<Answers> rndAnswer = new List<Answers>();
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            List<Answers> QA = JsonConvert.DeserializeObject<List<Answers>>(File.ReadAllText(@"C:\Users\1\source\repos\millionaire\Milionar\data.json"), settings);
            Random rnd = new Random();
            int Random = rnd.Next(0, QA.Count);


            foreach (int ints in Answered)
            {
                if (ints == Random) { Choose = false; }        
            }

            if (Choose)
            {
                Answered.Add(Random);
                for (int i=0; i<QA.Count;i++)
                {
                    if (Random == i)
                    {
                        rndAnswer.Add(new Answers
                        {
                            Question = QA[i].Question,
                            Answer = QA[i].Answer,
                            Good = QA[i].Good
                        });
                    }
                }
            }
            return rndAnswer;
        }
        
    }
}
