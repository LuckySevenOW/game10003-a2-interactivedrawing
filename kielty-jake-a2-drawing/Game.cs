// Include code libraries you need below (use the namespace).
using Raylib_cs;
using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:

        //Colors used
        Color bgWater = new Color(0x1b, 0x20, 0x2b);
        Color silhouette = new Color(0x14, 0x17, 0x1f);
        
        Color shadingDark = new Color(0x1c, 0x20, 0x2b);
        Color shadingMid = new Color(0x28, 0x2d, 0x3d);
        Color shadingLight = new Color(0x38, 0x3f, 0x55);
        Color shadingHighlight = new Color(0x5a, 0x65, 0x89);
        Color teeth = new Color(0xb2, 0xb3, 0xb7);
        Color lure = new Color(0xb8, 0xcc, 0xee);
       
        float[] xCoordinates = [];
        float[] yCoordinates = [];

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("It's a trap!");
            Window.SetSize(400, 400);

            int fishCount = Random.Integer(0, 10);
            xCoordinates = new float[fishCount];
            yCoordinates = new float[fishCount];

            for (int i = 0; i < fishCount; i++)
            {
                xCoordinates[i] = Random.Integer(30, 370);
                yCoordinates[i] = Random.Integer(30, 370);
            }


        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(bgWater);
            Draw.LineSize = 0;

            void DrawFish1(float x, float y)
            {
                //Fish
                Draw.FillColor = silhouette;
                Draw.LineSize = 0;
                Draw.Capsule(x + 15, y, x - 15, y, 10);
                Draw.Capsule(x + 5, y - 10, x - 5, y - 10, 6);
                Draw.Circle(x + 5, y + 5, 8);
                Draw.Triangle(x - 22, y, x - 30, y - 10, x - 28, y + 8);
            }

            void DrawFish2(float x, float y)
            {
                //Squid
                Draw.FillColor = silhouette;
                Draw.LineSize = 0;
                Draw.Ellipse(x, y, 60, 20);
                Draw.Capsule(x + 40, y, x + 20, y - 10, 5);
                Draw.Capsule(x + 40, y, x + 20, y + 10, 5);

                //Tentacles
                Draw.Capsule(x - 25, y, x - 35, y - 9, 2);
                Draw.Capsule(x - 25, y, x - 35, y + 9, 2);

                Draw.Capsule(x - 35, y - 9, x - 70, y - 11, 2);
                Draw.Capsule(x - 35, y + 9, x - 70, y + 11, 2);

                Draw.Ellipse(x - 70, y - 11, 14, 8);
                Draw.Ellipse(x - 70, y + 11, 14, 8);

                Draw.Capsule(x - 25, y - 2, x - 60, y - 4, 2);
                Draw.Capsule(x - 25, y + 2, x - 60, y + 4, 2);
            }

            void DrawFish3(float x, float y)
            {
                //Another Fish
                Draw.FillColor = silhouette;
                Draw.LineSize = 0;
                Draw.Ellipse(x, y, 65, 12);
                Draw.Triangle(x + 25, y, x + 38, y - 12, x + 32, y + 8);
                Draw.Quad(x - 15, y, x - 2, y - 12, x + 10, y - 12, x + 5, y);
                Draw.Capsule(x - 15, y, x - 10, y + 4, 5);
            }

            for (int i = 0; i < 2 ; i++)
            {
                DrawFish1(xCoordinates[i], yCoordinates[i]);
            }

            for (int i = 0; i < 2; i++)
            {
                DrawFish2(xCoordinates[i], yCoordinates[i]);
            }

            for (int i = 0; i < 2; i++)
            {
                DrawFish3(xCoordinates[i], yCoordinates[i]);
            }

            if (Input.IsMouseButtonDown(0))
            {
                //Angler Fish

                //Tail
                Draw.FillColor = silhouette;
                Draw.Quad(360, 110, 390, 90, 380, 160, 360, 150);
                Draw.FillColor = bgWater;
                Draw.Ellipse(391, 103, 24, 24);
                Draw.Ellipse(390, 120, 20, 15);
                Draw.Ellipse(387, 135, 20, 15);
                Draw.Ellipse(385, 150, 20, 15);
                Draw.Ellipse(380, 160, 40, 16);

                //Dorsal Fin
                Draw.FillColor = silhouette;
                Draw.Capsule(290, 130, 310, 110, 15);

                //Rear Body
                Draw.FillColor = silhouette;
                Draw.Quad(320, 115, 360, 110, 360, 150, 335, 160);

                //Rear Body Dark Color Segment
                Draw.FillColor = shadingDark;
                Draw.Quad(260, 120, 320, 115, 335, 160, 280, 210);
                Draw.Ellipse(327, 137, 35, 45);

                //Main Body Mid Color Segment
                Draw.FillColor = shadingMid;
                Draw.Ellipse(298, 161, 50, 75);
                Draw.Ellipse(278, 143, 75, 50);
                Draw.Circle(260, 180, 60);

                //Main Body Light Color Segment
                Draw.FillColor = shadingLight;
                Draw.Ellipse(260, 220, 110, 120);
                Draw.Ellipse(258, 177, 100, 100);
                Draw.Ellipse(250, 150, 75, 50);
                Draw.Circle(260, 190, 56);

                //Main Body Highlight Color Segment
                Draw.FillColor = shadingHighlight;
                Draw.Ellipse(227, 175, 55, 80);
                Draw.Ellipse(240, 160, 72, 53);
                Draw.Ellipse(255, 175, 66, 69);
                Draw.Ellipse(258, 200, 85, 120);
                Draw.Ellipse(250, 232, 90, 80);

                //Side Fin
                Draw.FillColor = shadingHighlight;
                Draw.Triangle(300, 195, 340, 150, 335, 210);
                Draw.FillColor = bgWater;
                Draw.Ellipse(340, 170, 18, 25);
                Draw.Ellipse(340, 185, 25, 15);
                Draw.Ellipse(337, 197, 25, 12);
                Draw.Ellipse(336, 205, 20, 7);
                Draw.Ellipse(340, 210, 20, 7);

                //Mouth
                Draw.FillColor = bgWater;
                Draw.Ellipse(230, 235, 110, 70);

                //Top Teeth
                Draw.FillColor = teeth;
                Draw.Triangle(210, 202, 215, 200, 223, 228);
                Draw.Triangle(217, 200, 222, 200, 229, 229);
                Draw.Triangle(224, 200, 229, 200, 236, 230);
                Draw.Triangle(231, 200, 236, 200, 241, 230);
                Draw.Triangle(238, 200, 243, 200, 249, 230);
                Draw.Triangle(245, 201, 250, 202, 254, 228);
                Draw.Triangle(252, 203, 257, 204, 261, 227);
                Draw.Triangle(259, 205, 265, 208, 268, 225);
                Draw.Triangle(267, 209, 273, 211, 273, 220);

                //Bottom Teeth
                Draw.Triangle(237, 270, 242, 269, 232, 235);
                Draw.Triangle(244, 269, 249, 268, 238, 235);
                Draw.Triangle(251, 268, 256, 267, 243, 235);
                Draw.Triangle(258, 267, 263, 266, 246, 235);
                Draw.Triangle(265, 263, 270, 261, 254, 235);
                Draw.Triangle(272, 259, 277, 257, 262, 235);
                Draw.Triangle(278, 258, 281, 252, 267, 235);
                Draw.Triangle(282, 252, 283, 245, 272, 235);

                //Eye
                Draw.FillColor = Color.Black;
                Draw.Circle(240, 180, 7);
                Draw.FillColor = Color.White;
                Draw.Circle(236, 178, 2);

                //Lure
                Draw.LineSize = 7;
                Draw.LineColor = shadingHighlight;
                Draw.Line(225, 140, 200, 110);
                Draw.Line(200, 110, 180, 100);
                Draw.Line(180, 100, 160, 110);
                Draw.Line(160, 110, 155, 140);
                Draw.Line(155, 140, 153, 180);
                Draw.LineSize = 3;
                Draw.FillColor = lure;
                Draw.Circle(153, 185, 10);


                //Prey Fish

                Draw.LineSize = 0;

                //Dorsal Fin
                Draw.FillColor = shadingMid;
                Draw.Capsule(95, 234, 107, 228, 5);

                //Body
                Draw.FillColor = silhouette;
                Draw.Capsule(90, 250, 120, 235, 10);
                Draw.FillColor = shadingDark;
                Draw.Capsule(99, 244, 120, 235, 10);
                Draw.FillColor = shadingMid;
                Draw.Capsule(105, 241, 120, 235, 10);
                Draw.FillColor = shadingLight;
                Draw.Capsule(110, 239, 120, 235, 10);
                Draw.FillColor = shadingHighlight;
                Draw.Capsule(115, 236, 120, 235, 10);

                //Side Fin
                Draw.FillColor = shadingLight;
                Draw.Triangle(95, 250, 112, 243, 98, 260);

                //Tail
                Draw.FillColor = silhouette;
                Draw.Capsule(72, 246, 78, 260, 8);
                Draw.FillColor = bgWater;
                Draw.Capsule(63, 250, 69, 264, 6);

                //Eye
                Draw.FillColor = Color.Black;
                Draw.Circle(120, 232, 5);
                Draw.FillColor = Color.White;
                Draw.Circle(122, 230, 2);
            }
            else
            {
                //Angler Fish

                //Tail
                Draw.FillColor = silhouette;
                Draw.Quad(360, 110, 390, 90, 380, 160, 360, 150);
                Draw.FillColor = bgWater;
                Draw.Ellipse(391, 103, 24, 24);
                Draw.Ellipse(390, 120, 20, 15);
                Draw.Ellipse(387, 135, 20, 15);
                Draw.Ellipse(385, 150, 20, 15);
                Draw.Ellipse(380, 160, 40, 16);

                //Dorsal Fin
                Draw.FillColor = silhouette;
                Draw.Capsule(290, 130, 310, 110, 15);

                //Rear Body
                Draw.Quad(320, 115, 360, 110, 360, 150, 335, 160);

                //Rear Body Dark Color Segment
                Draw.Quad(260, 120, 320, 115, 335, 160, 280, 210);
                Draw.Ellipse(327, 137, 35, 45);

                //Main Body Mid Color Segment
                Draw.Ellipse(298, 161, 50, 75);
                Draw.Ellipse(278, 143, 75, 50);
                Draw.Circle(260, 180, 60);

                //Main Body Light Color Segment
                Draw.Ellipse(260, 220, 110, 120);
                Draw.Ellipse(258, 177, 100, 100);
                Draw.Ellipse(250, 150, 75, 50);
                Draw.Circle(260, 190, 56);

                //Main Body Highlight Color Segment
                Draw.Ellipse(227, 175, 55, 80);
                Draw.Ellipse(240, 160, 72, 53);
                Draw.Ellipse(255, 175, 66, 69);
                Draw.Ellipse(258, 200, 85, 120);
                Draw.Ellipse(250, 232, 90, 80);

                //Side Fin
                Draw.Triangle(300, 195, 340, 150, 335, 210);
                Draw.FillColor = bgWater;
                Draw.Ellipse(340, 170, 18, 25);
                Draw.Ellipse(340, 185, 25, 15);
                Draw.Ellipse(337, 197, 25, 12);
                Draw.Ellipse(336, 205, 20, 7);
                Draw.Ellipse(340, 210, 20, 7);

                //Mouth
                Draw.FillColor = bgWater;
                Draw.Ellipse(230, 235, 110, 70);

                //Top Teeth
                Draw.FillColor = silhouette;
                Draw.Triangle(210, 202, 215, 200, 223, 228);
                Draw.Triangle(217, 200, 222, 200, 229, 229);
                Draw.Triangle(224, 200, 229, 200, 236, 230);
                Draw.Triangle(231, 200, 236, 200, 241, 230);
                Draw.Triangle(238, 200, 243, 200, 249, 230);
                Draw.Triangle(245, 201, 250, 202, 254, 228);
                Draw.Triangle(252, 203, 257, 204, 261, 227);
                Draw.Triangle(259, 205, 265, 208, 268, 225);
                Draw.Triangle(267, 209, 273, 211, 273, 220);

                //Bottom Teeth
                Draw.Triangle(237, 270, 242, 269, 232, 235);
                Draw.Triangle(244, 269, 249, 268, 238, 235);
                Draw.Triangle(251, 268, 256, 267, 243, 235);
                Draw.Triangle(258, 267, 263, 266, 246, 235);
                Draw.Triangle(265, 263, 270, 261, 254, 235);
                Draw.Triangle(272, 259, 277, 257, 262, 235);
                Draw.Triangle(278, 258, 281, 252, 267, 235);
                Draw.Triangle(282, 252, 283, 245, 272, 235);

                //Eye
                Draw.Circle(240, 180, 7);
                Draw.Circle(236, 178, 2);

                //Lure
                Draw.LineSize = 7;
                Draw.LineColor = silhouette;
                Draw.Line(225, 140, 200, 110);
                Draw.Line(200, 110, 180, 100);
                Draw.Line(180, 100, 160, 110);
                Draw.Line(160, 110, 155, 140);
                Draw.Line(155, 140, 153, 180);
                Draw.LineSize = 3;
                Draw.FillColor = silhouette;
                Draw.Circle(153, 185, 10);


                //Prey Fish

                Draw.LineSize = 0;
                Draw.FillColor = silhouette;

                //Dorsal Fin
                Draw.Capsule(95, 234, 107, 228, 5);

                //Body
                Draw.Capsule(90, 250, 120, 235, 10);
                Draw.Capsule(99, 244, 120, 235, 10);
                Draw.Capsule(105, 241, 120, 235, 10);
                Draw.Capsule(110, 239, 120, 235, 10);
                Draw.Capsule(115, 236, 120, 235, 10);

                //Side Fin
                Draw.Triangle(95, 250, 112, 243, 98, 260);

                //Tail
                Draw.Capsule(72, 246, 78, 260, 8);
                Draw.FillColor = bgWater;
                Draw.Capsule(63, 250, 69, 264, 6);

                //Eye
                Draw.FillColor = silhouette;
                Draw.Circle(120, 232, 5);
                Draw.Circle(122, 230, 2);
            }

         
            

            







        }
    }
}
