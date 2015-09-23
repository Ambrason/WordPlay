using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WordPlay.Repositories
{
    public class ImageGameRepository
    {
        public void button1_Click(object sender, EventArgs e)
        {
            Image[] images = new Image[5];
            images[0] = Image.FromFile(@"C:\Users\elev\Source\Repos\WordPlay\WordPlay\WordPlay\Images\ImageGame\airplane.jpg");
            images[1] = Image.FromFile(@"C:\Users\elev\Source\Repos\WordPlay\WordPlay\WordPlay\Images\ImageGame\bear.jpg");
            images[2] = Image.FromFile(@"C:\Users\elev\Source\Repos\WordPlay\WordPlay\WordPlay\Images\ImageGame\bicycle.jpg");
            images[3] = Image.FromFile(@"C:\Users\elev\Source\Repos\WordPlay\WordPlay\WordPlay\Images\ImageGame\car.jpg");
            images[4] = Image.FromFile(@"C:\Users\elev\Source\Repos\WordPlay\WordPlay\WordPlay\Images\ImageGame\boat.jpg");


            string[] strNames = new String[5];
            strNames[0] = "airplane";
            strNames[1] = "bear";
            strNames[2] = "bicycle";
            strNames[3] = "car";
            strNames[4] = "boat";


            string[] strAnswers = new String[5];
            //strAnswers[0] = "";
            //strAnswers[1] = "";
            //strAnswers[2] = "";
            //strAnswers[3] = "";
            //strAnswers[4] = "";



            for (int i = 1; i <= 5; i++){
                if (strAnswers[i] == strNames[i]){
                    //om input är rätt
                }
            }
        }
    }
}