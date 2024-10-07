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

        //The colors I used.
        Color bgWater = new Color(0x10, 0x12, 0x19);
        Color silhouette = new Color(0x14, 0x16, 0x1F);
        Color bgSilhouette = new Color(0x0D, 0x0E, 0x13);

        Color shadingDark = new Color(0x1c, 0x20, 0x2b);
        Color shadingMid = new Color(0x28, 0x2d, 0x3d);
        Color shadingLight = new Color(0x38, 0x3f, 0x55);
        Color shadingHighlight = new Color(0x5a, 0x65, 0x89);

        Color teeth = new Color(0xb2, 0xb3, 0xb7);
        Color lure = new Color(0xb8, 0xcc, 0xee);

        //Initializes the x and y coordinates for the background creatures, the fish and squid. 

        //Fish Coordinates
        float[] xCoordinates1 = [];
        float[] yCoordinates1 = [];

        //Squid Coordinates
        float[] xCoordinates2 = [];
        float[] yCoordinates2 = [];

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            //Sets up window size and title. I couldn't think of anything really interesting to put for the name, so I just chose an old and dead meme
            //because its somewhat relevant to the anglerfish luring other fish.
            Window.SetTitle("It's a trap!");
            Window.SetSize(400, 400);

            //Generates a random number between 1 and 6 for how many fish will appear in the background, and then sets the size of the array according to that number.
            int fishCount1 = Random.Integer(1, 6);
            xCoordinates1 = new float[fishCount1];
            yCoordinates1 = new float[fishCount1];

            //Randomly generates x and y coordinates for the positions of the fish in the background, based on how many fish are going to appear. 
            for (int i = 0; i < fishCount1; i++)
            {
                xCoordinates1[i] = Random.Integer(30, 370);
                yCoordinates1[i] = Random.Integer(30, 370);
            }

            //Generates a random number between 1 and 6 for how many squid will appear in the background, and then sets the size of the array according to that number.
            int fishCount2 = Random.Integer(1, 6);
            xCoordinates2 = new float[fishCount2];
            yCoordinates2 = new float[fishCount2];

            //Randomly generates x and y coordinates for the positions of the squid in the background, based on how many are going to appear. 
            for (int i = 0; i < fishCount2; i++)
            {
                xCoordinates2[i] = Random.Integer(30, 370);
                yCoordinates2[i] = Random.Integer(30, 370);
            }
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            //Clears background and sets it to the background water color.
            Window.ClearBackground(bgWater);
            Draw.LineSize = 0;

            //Draws a fish in the background at points x,y
            void drawFish(float x, float y)
            {
                Draw.FillColor = bgSilhouette;
                Draw.LineSize = 0;
                Draw.Ellipse(x, y, 65, 12);
                Draw.Triangle(x + 25, y, x + 38, y - 12, x + 32, y + 8);
                Draw.Quad(x - 15, y, x - 2, y - 12, x + 10, y - 12, x + 5, y);
                Draw.Capsule(x - 15, y, x - 10, y + 4, 5);
            }

            //Draws a squid in the background at points x,y
            void drawSquid(float x, float y)
            {
                //Squid
                Draw.FillColor = bgSilhouette;
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

            //Draws the background fish based on the randomly generated positions determined previously.
            for (int i = 0; i < xCoordinates1.Length; i++)
            {
                drawFish(xCoordinates1[i], yCoordinates1[i]);
            }

            //Draws the background squid based on the randomly generated positions determined previously.
            for (int i = 0; i < xCoordinates2.Length; i++)
            {
                drawSquid(xCoordinates2[i], yCoordinates2[i]);
            }

            //If the mouse button is pressed down, it shows the illuminated version, otherwise it shows the silhouetted version.
            //I would have used a function to avoid having to duplicate the drawing in the code, but it would have ruined
            //all of the colors and layers, so this is the best I could manage.
            if (Input.IsMouseButtonDown(0))
            {
                //Angler Fish

                //Rear Body
                Draw.FillColor = silhouette;
                Draw.Quad(320, 115, 360, 110, 360, 150, 335, 160);

                //Tail Fin
                Draw.Triangle(360, 110, 392, 90, 360, 150);
                Draw.Triangle(360, 110, 395, 105, 360, 150);
                Draw.Triangle(360, 110, 395, 120, 360, 150);
                Draw.Triangle(360, 110, 392, 135, 360, 150);
                Draw.Triangle(360, 110, 389, 145, 360, 150);
                Draw.Triangle(360, 110, 383, 155, 360, 150);
                Draw.Triangle(360, 110, 378, 160, 360, 150);

                //Dorsal Fin
                Draw.Triangle(270, 130, 298, 93, 294, 130);
                Draw.Triangle(270, 130, 304, 94, 294, 130);
                Draw.Triangle(270, 130, 311, 95, 294, 130);
                Draw.Triangle(270, 130, 318, 97, 294, 130);
                Draw.Triangle(270, 130, 325, 99, 294, 130);
                Draw.Triangle(275, 125, 329, 104, 294, 130);
                Draw.Triangle(275, 125, 331, 108, 294, 130);
                Draw.Triangle(275, 125, 332, 111, 294, 130);

                //Rear Body Dark Color Segment
                Draw.FillColor = shadingDark;
                Draw.Quad(260, 120, 320, 115, 335, 160, 280, 210);
                Draw.Ellipse(327, 137, 35, 45);

                //Main Body Mid Color Segment
                Draw.FillColor = shadingMid;
                Draw.Ellipse(298, 161, 50, 75);
                Draw.Ellipse(278, 143, 73, 50);
                Draw.Ellipse(260, 137, 67, 30);

                //Top Teeth
                Draw.FillColor = teeth;
                Draw.Triangle(210, 200, 215, 198, 223, 228);
                Draw.Triangle(217, 198, 222, 198, 229, 229);
                Draw.Triangle(224, 198, 229, 198, 236, 230);
                Draw.Triangle(231, 198, 236, 198, 241, 230);
                Draw.Triangle(238, 198, 243, 198, 249, 230);
                Draw.Triangle(245, 199, 250, 200, 254, 228);
                Draw.Triangle(252, 201, 257, 202, 261, 227);
                Draw.Triangle(259, 203, 265, 206, 268, 225);
                Draw.Triangle(267, 207, 273, 209, 273, 220);

                //Bottom Teeth
                Draw.Triangle(237, 272, 242, 271, 232, 235);
                Draw.Triangle(244, 271, 249, 270, 238, 235);
                Draw.Triangle(251, 270, 256, 269, 243, 235);
                Draw.Triangle(258, 269, 263, 268, 246, 235);
                Draw.Triangle(265, 266, 270, 263, 254, 235);
                Draw.Triangle(272, 261, 277, 259, 262, 235);
                Draw.Triangle(278, 260, 281, 254, 267, 235);
                Draw.Triangle(282, 254, 283, 247, 272, 235);

                //Main Body Light Color Segment
                Draw.FillColor = shadingLight;
                Draw.Triangle(227, 270, 263, 275, 263, 281);
                Draw.Quad(263, 275, 278, 268, 278, 277, 263, 281);
                Draw.Triangle(278, 268, 300, 262, 278, 277);
                Draw.Quad(278, 268, 293, 245, 310, 245, 300, 262);
                Draw.Ellipse(295, 185, 40, 60);
                Draw.Ellipse(285, 175, 55, 60);
                Draw.Ellipse(270, 165, 70, 50);
                Draw.Ellipse(275, 160, 55, 50);
                Draw.Ellipse(258, 152, 75, 50);
                Draw.Ellipse(253, 150, 79, 50);
                Draw.Ellipse(300, 200, 35, 70);
                Draw.Ellipse(303, 213, 25, 80);

                //Main Body Highlight Color Segment
                Draw.FillColor = shadingHighlight;
                Draw.Ellipse(227, 175, 55, 50);
                Draw.Ellipse(227, 165, 55, 50);
                Draw.Ellipse(238, 155, 65, 50);
                Draw.Ellipse(238, 155, 65, 50);
                Draw.Ellipse(247, 155, 53, 50);
                Draw.Ellipse(255, 170, 70, 70);
                Draw.Ellipse(270, 180, 47, 50);
                Draw.Ellipse(275, 169, 35, 40);
                Draw.Ellipse(286, 190, 25, 60);
                Draw.Ellipse(292, 200, 20, 70);
                Draw.Ellipse(292, 200, 20, 70);
                Draw.Quad(227, 175, 227, 200, 201, 201, 201, 175);
                Draw.Quad(250, 202, 273, 211, 270, 182, 293, 191);
                Draw.Quad(273, 211, 280, 215, 280, 200, 273, 200);

                //Bottom Jaw Highlight Color
                Draw.Ellipse(290, 227, 16, 45);
                Draw.Ellipse(294, 220, 15, 45);
                Draw.Quad(237, 270, 263, 266, 263, 275, 227, 270);
                Draw.Quad(263, 266, 272, 259, 278, 268, 263, 275);
                Draw.Triangle(272, 259, 278, 258, 278, 268);
                Draw.Quad(278, 258, 283, 245, 295, 245, 278, 268);
                Draw.Quad(283, 245, 282, 200, 302, 200, 293, 245);

                //Side Fin
                Draw.FillColor = shadingHighlight;
                Draw.Triangle(300, 195, 340, 150, 315, 200);
                Draw.Triangle(300, 195, 345, 160, 315, 200);
                Draw.Triangle(300, 195, 346, 170, 315, 200);
                Draw.Triangle(300, 195, 347, 180, 315, 200);
                Draw.Triangle(300, 195, 347, 190, 315, 200);
                Draw.Triangle(300, 195, 346, 197, 315, 200);

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
                Draw.Triangle(95, 250, 108, 243, 98, 260);

                //Tail
                Draw.FillColor = silhouette;
                Draw.Capsule(73, 246, 81, 260, 6);

                //Eye
                Draw.FillColor = Color.Black;
                Draw.Circle(120, 232, 5);
                Draw.FillColor = Color.White;
                Draw.Circle(122, 230, 2);
            }

            else
            {
                //Angler Fish

                //Setting all to the silhouette color since it's just meant to be one color
                Draw.FillColor = silhouette;
                Draw.LineColor = silhouette;

                //Rear Body
                Draw.Quad(320, 115, 360, 110, 360, 150, 335, 160);
                Draw.Quad(260, 120, 320, 115, 335, 160, 280, 210);
                Draw.Ellipse(327, 137, 35, 45);

                //Tail Fin
                Draw.Triangle(360, 110, 392, 90, 360, 150);
                Draw.Triangle(360, 110, 395, 105, 360, 150);
                Draw.Triangle(360, 110, 395, 120, 360, 150);
                Draw.Triangle(360, 110, 392, 135, 360, 150);
                Draw.Triangle(360, 110, 389, 145, 360, 150);
                Draw.Triangle(360, 110, 383, 155, 360, 150);
                Draw.Triangle(360, 110, 378, 160, 360, 150);

                //Dorsal Fin
                Draw.Triangle(270, 130, 298, 93, 294, 130);
                Draw.Triangle(270, 130, 304, 94, 294, 130);
                Draw.Triangle(270, 130, 311, 95, 294, 130);
                Draw.Triangle(270, 130, 318, 97, 294, 130);
                Draw.Triangle(270, 130, 325, 99, 294, 130);
                Draw.Triangle(275, 125, 329, 104, 294, 130);
                Draw.Triangle(275, 125, 331, 108, 294, 130);
                Draw.Triangle(275, 125, 332, 111, 294, 130);

                //Main Body Mid Color Segment
                Draw.Ellipse(298, 161, 50, 75);
                Draw.Ellipse(278, 143, 73, 50);
                Draw.Ellipse(260, 137, 67, 30);

                //Top Teeth
                Draw.Triangle(210, 200, 215, 198, 223, 228);
                Draw.Triangle(217, 198, 222, 198, 229, 229);
                Draw.Triangle(224, 198, 229, 198, 236, 230);
                Draw.Triangle(231, 198, 236, 198, 241, 230);
                Draw.Triangle(238, 198, 243, 198, 249, 230);
                Draw.Triangle(245, 199, 250, 200, 254, 228);
                Draw.Triangle(252, 201, 257, 202, 261, 227);
                Draw.Triangle(259, 203, 265, 206, 268, 225);
                Draw.Triangle(267, 207, 273, 209, 273, 220);

                //Bottom Teeth
                Draw.Triangle(237, 272, 242, 271, 232, 235);
                Draw.Triangle(244, 271, 249, 270, 238, 235);
                Draw.Triangle(251, 270, 256, 269, 243, 235);
                Draw.Triangle(258, 269, 263, 268, 246, 235);
                Draw.Triangle(265, 266, 270, 263, 254, 235);
                Draw.Triangle(272, 261, 277, 259, 262, 235);
                Draw.Triangle(278, 260, 281, 254, 267, 235);
                Draw.Triangle(282, 254, 283, 247, 272, 235);

                //Main Body Light Color Segment
                Draw.Triangle(227, 270, 263, 275, 263, 281);
                Draw.Quad(263, 275, 278, 268, 278, 277, 263, 281);
                Draw.Triangle(278, 268, 300, 262, 278, 277);
                Draw.Quad(278, 268, 293, 245, 310, 245, 300, 262);
                Draw.Ellipse(295, 185, 40, 60);
                Draw.Ellipse(285, 175, 55, 60);
                Draw.Ellipse(270, 165, 70, 50);
                Draw.Ellipse(275, 160, 55, 50);
                Draw.Ellipse(258, 152, 75, 50);
                Draw.Ellipse(253, 150, 79, 50);
                Draw.Ellipse(300, 200, 35, 70);
                Draw.Ellipse(303, 213, 25, 80);

                //Main Body Highlight Color Segment
                Draw.Ellipse(227, 175, 55, 50);
                Draw.Ellipse(227, 165, 55, 50);
                Draw.Ellipse(238, 155, 65, 50);
                Draw.Ellipse(238, 155, 65, 50);
                Draw.Ellipse(247, 155, 53, 50);
                Draw.Ellipse(255, 170, 70, 70);
                Draw.Ellipse(270, 180, 47, 50);
                Draw.Ellipse(275, 169, 35, 40);
                Draw.Ellipse(286, 190, 25, 60);
                Draw.Ellipse(292, 200, 20, 70);
                Draw.Ellipse(292, 200, 20, 70);
                Draw.Quad(227, 175, 227, 200, 201, 201, 201, 175);
                Draw.Quad(250, 202, 273, 211, 270, 182, 293, 191);
                Draw.Quad(273, 211, 280, 215, 280, 200, 273, 200);

                //Bottom Jaw Highlight Color
                Draw.Ellipse(290, 227, 16, 45);
                Draw.Ellipse(294, 220, 15, 45);
                Draw.Quad(237, 270, 263, 266, 263, 275, 227, 270);
                Draw.Quad(263, 266, 272, 259, 278, 268, 263, 275);
                Draw.Triangle(272, 259, 278, 258, 278, 268);
                Draw.Quad(278, 258, 283, 245, 295, 245, 278, 268);
                Draw.Quad(283, 245, 282, 200, 302, 200, 293, 245);

                //Side Fin
                Draw.Triangle(300, 195, 340, 150, 315, 200);
                Draw.Triangle(300, 195, 345, 160, 315, 200);
                Draw.Triangle(300, 195, 346, 170, 315, 200);
                Draw.Triangle(300, 195, 347, 180, 315, 200);
                Draw.Triangle(300, 195, 347, 190, 315, 200);
                Draw.Triangle(300, 195, 346, 197, 315, 200);

                //Eye
                Draw.Circle(240, 180, 7);
                Draw.Circle(236, 178, 2);

                //Lure
                Draw.LineSize = 7;
                Draw.Line(225, 140, 200, 110);
                Draw.Line(200, 110, 180, 100);
                Draw.Line(180, 100, 160, 110);
                Draw.Line(160, 110, 155, 140);
                Draw.Line(155, 140, 153, 180);
                Draw.LineSize = 3;
                Draw.Circle(153, 185, 10);

                //Prey Fish

                Draw.LineSize = 0;

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
                Draw.Capsule(73, 246, 81, 260, 6);

                //Eye
                Draw.Circle(120, 232, 5);
                Draw.Circle(122, 230, 2);
            }
        }
    }
}
