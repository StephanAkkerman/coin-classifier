// Made by Stephan Akkerman (6397514) and Tim Koornstra (6435777) - Assignment pair 2

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace INFOIBV
{
    public partial class INFOIBV : Form
    {
        private Bitmap InputImage;
        private Bitmap OutputImage;

        private byte[,] workingImage;

        public INFOIBV()
        {
            InitializeComponent();
        }

        /*
         * loadButton_Click: process when user clicks "Load" button
         */
        private void loadImageButton_Click(object sender, EventArgs e)
        {
            if (openImageDialog.ShowDialog() == DialogResult.OK)             // open file dialog
            {
                string file = openImageDialog.FileName;                     // get the file name
                imageFileName.Text = file;                                  // show file name
                if (InputImage != null) InputImage.Dispose();               // reset image
                InputImage = new Bitmap(file);                              // create new Bitmap from file
                workingImage = new byte[InputImage.Size.Width, InputImage.Size.Height];
                if (InputImage.Size.Height <= 0 || InputImage.Size.Width <= 0 ||
                    InputImage.Size.Height > 512 || InputImage.Size.Width > 512) // dimension check (may be removed or altered)
                    MessageBox.Show("Error in image dimensions (have to be > 0 and <= 512)");
                else
                    pictureBox1.Image = (Image)InputImage;                 // display input image
            }
        }

        /*
         * applyButton_Click: process when user clicks "Apply" button
         */
        private void applyButton_Click(object sender, EventArgs e)
        {
            if (InputImage == null) return;                                 // get out if no input image
            if (OutputImage != null) OutputImage.Dispose();                 // reset output image
            OutputImage = new Bitmap(InputImage.Size.Width, InputImage.Size.Height); // create new output image
            Color[,] Image = new Color[InputImage.Size.Width, InputImage.Size.Height]; // create array to speed-up operations (Bitmap functions are very slow)

            // copy input Bitmap to array            
            for (int x = 0; x < InputImage.Size.Width; x++)                 // loop over columns
                for (int y = 0; y < InputImage.Size.Height; y++)            // loop over rows
                {
                    Image[x, y] = InputImage.GetPixel(x, y);                // set pixel color in array at (x,y)
                }

            // ====================================================================
            // =================== YOUR FUNCTION CALLS GO HERE ====================
            // Alternatively you can create buttons to invoke certain functionality
            // ====================================================================

            // Beware that although multiple checkboxes can be checked at the same time, operations will happen from top to bottom.
            // By checking wantGrayscale, the image will be reloaded. If you want to apply operations in a different order than
            // top to bottom, uncheck wantGrayscale and you can apply whatever operator is desired.
            // Also, keep in mind that textboxes are parsed from local language settings. If your system's language is Dutch,
            // a float value of 1.4 would not result in a normal application of a function. If your language is not in English, please
            // use ',' for floats and doubles. If it is, please use '.' to indicate decimals.

            if (wantGrayscale.Checked)                              // convert image to grayscale
                workingImage = convertToGrayscale(Image);
            if (filterBox.Checked)                                  // use a filter over an image
            {
                if (filterCombo.SelectedItem.ToString() == "Median")
                    workingImage = medianFilter(workingImage, Byte.Parse(sizeBox.Text));
            }          
            if (sharpenBox.Checked)                                 // sharpen edges
                workingImage = sharpenEdges(workingImage, float.Parse(sharpBox.Text), Byte.Parse(smoothSizeBox.Text), float.Parse(smoothBox.Text));
            if (closeBox.Checked)
                workingImage = closeImage(workingImage, createStructuringElement(strucShapeCombo.Text.ToLower(), int.Parse(strucSizeBox.Text)));
            if (edgeBox.Checked)                                    // calculate edges
            {
                sbyte[,] hX = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
                sbyte[,] hY = { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

                workingImage = cannyEdge(workingImage, hX, hY);
            }
            if (thresholdBox.Checked)                                // threshold an image over a certain value
                workingImage = thresholdImage(workingImage, Byte.Parse(thresholdField.Text));           
            if (circleDetect.Checked)
                workingImage = circleDetection(workingImage, int.Parse(rMin.Text), int.Parse(rMax.Text), 30, 0.25);
            
            // ==================== END OF YOUR FUNCTION CALLS ====================
            // ====================================================================

            // copy array to output Bitmap
            for (int x = 0; x < workingImage.GetLength(0); x++)             // loop over columns
                for (int y = 0; y < workingImage.GetLength(1); y++)         // loop over rows
                {
                    Color newColor = Color.FromArgb(workingImage[x, y], workingImage[x, y], workingImage[x, y]);
                    OutputImage.SetPixel(x, y, newColor);                   // set the pixel color at coordinate (x,y)
                }

            pictureBox2.Image = (Image)OutputImage;                         // display output image
        }

        // A button to do all the Pre-Processing using the input boxes.
        private void preButton_Click(object sender, EventArgs e)
        {
            if (InputImage == null) return;                                 // get out if no input image
            if (OutputImage != null) OutputImage.Dispose();                 // reset output image
            OutputImage = new Bitmap(InputImage.Size.Width, InputImage.Size.Height); // create new output image
            Color[,] Image = new Color[InputImage.Size.Width, InputImage.Size.Height]; // create array to speed-up operations (Bitmap functions are very slow)

            // copy input Bitmap to array            
            for (int x = 0; x < InputImage.Size.Width; x++)                 // loop over columns
                for (int y = 0; y < InputImage.Size.Height; y++)            // loop over rows
                {
                    Image[x, y] = InputImage.GetPixel(x, y);                // set pixel color in array at (x,y)
                }

            sbyte[,] hX = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            sbyte[,] hY = { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

            workingImage = convertToGrayscale(Image);
            workingImage = medianFilter(workingImage, Byte.Parse(sizeBox.Text));
            workingImage = sharpenEdges(workingImage, float.Parse(sharpBox.Text), Byte.Parse(smoothSizeBox.Text), float.Parse(smoothBox.Text));
            workingImage = closeImage(workingImage, createStructuringElement(strucShapeCombo.Text.ToLower(), int.Parse(strucSizeBox.Text)));
            workingImage = cannyEdge(workingImage, hX, hY);
            workingImage = thresholdImage(workingImage, Byte.Parse(thresholdField.Text));

            for (int x = 0; x < workingImage.GetLength(0); x++)             // loop over columns
                for (int y = 0; y < workingImage.GetLength(1); y++)         // loop over rows
                {
                    Color newColor = Color.FromArgb(workingImage[x, y], workingImage[x, y], workingImage[x, y]);
                    OutputImage.SetPixel(x, y, newColor);                   // set the pixel color at coordinate (x,y)
                }

            pictureBox2.Image = (Image)OutputImage;                         // display output image
        }

        // A button function to classify the image and return an image with a bounding box around each coin, along with a count of how much of what has been
        // classified.
        private void classifyButton_Click(object sender, EventArgs e)
        {
            if (InputImage == null) return;                                 // get out if no input image
            if (OutputImage != null) OutputImage.Dispose();                 // reset output image
            OutputImage = new Bitmap(InputImage.Size.Width, InputImage.Size.Height); // create new output image
            Color[,] Image = new Color[InputImage.Size.Width, InputImage.Size.Height]; // create array to speed-up operations (Bitmap functions are very slow)

            // copy input Bitmap to array            
            for (int x = 0; x < InputImage.Size.Width; x++)                 // loop over columns
                for (int y = 0; y < InputImage.Size.Height; y++)            // loop over rows
                {
                    Image[x, y] = InputImage.GetPixel(x, y);                // set pixel color in array at (x,y)
                }

            // ColorNoise is based on the slider, if there is a lot of noise the threshold in getColors will be a bigger value 
            float colorNoise = (float)(noiseTrack.Value / 1.5);
            List<Tuple<int, int, int>> circles = circleLocations(workingImage, int.Parse(rMin.Text), int.Parse(rMax.Text), 30, 0.25);
            List<Color> colors = getColors(Image, circles, colorNoise);
            List<List<Tuple<Point, Point>>> boundingBoxes = new List<List<Tuple<Point, Point>>>();

            byte[,] flipImage = convertToGrayscale(Image);
            List<bool> front = new List<bool>();

            int countRed = 0;
            int countBlue = 0;
            int countGreen = 0;
            int countYellow = 0;
            int countBlack = 0;

            foreach (Tuple<int, int, int> t in circles)
            {
                boundingBoxes.Add(createBoundingBox(t));
                front.Add(isFront(flipImage, t));
            }

            foreach (List<Tuple<Point, Point>> l in boundingBoxes)
            {
                int index = boundingBoxes.IndexOf(l);
                Color color = colors[index];
                bool notBack = front[index];

                if (color == Color.Red)
                    countRed++;
                if (color == Color.Blue)
                    countBlue++;
                if (color == Color.YellowGreen)
                    countYellow++;
                if (color == Color.Green)
                    countGreen++;
                if (color == Color.Black)
                    countBlack++;
                foreach (Tuple<Point, Point> t in l)
                {
                    int x1 = t.Item1.X;
                    int y1 = t.Item1.Y;

                    int x2 = t.Item2.X;
                    int y2 = t.Item2.Y;

                    if (x1 != x2)
                        for (int x = x1; x < x2; x++)
                        {
                            try
                            {
                                // To create a dashed bounding box to describe the back.
                                if (!notBack)
                                {
                                    if (x % 10 > 3 && x % 10 < 9)
                                        for (int y = y1 - 1; y < y1 + 1; y++)
                                            Image[x, y] = color;
                                }
                                else
                                    for (int y = y1 - 1; y < y1 + 1; y++)
                                        Image[x, y] = color;
                            }
                            catch { }
                        }
                    else if (x1 == x2)
                        for (int y = y1; y < y2; y++)
                        {
                            try
                            {
                                if (!notBack)
                                {
                                    if (y % 10 > 3 && y % 10 < 9)
                                        for (int x = x1 - 1; x < x1 + 1; x++)
                                            Image[x, y] = color;
                                }
                                else
                                    for (int x = x1 - 1; x < x1 + 1; x++)
                                        Image[x, y] = color;

                            }
                            catch { }
                        }
                }
            }

            copperCount.Text = $"Found {countRed} 1 or 2 or 5 cent coin(s)";
            goldCount.Text = $"Found {countYellow} 10 or 20 or 50 cent coin(s)";
            countOneEu.Text = $"Found {countBlue} 1 euro coin(s)";
            countTwoEu.Text = $"Found {countGreen} 2 euro coin(s)";
            countUnclassified.Text = $"Found {countBlack} unidentified circle(s)";

            for (int x = 0; x < workingImage.GetLength(0); x++)             // loop over columns
                for (int y = 0; y < workingImage.GetLength(1); y++)         // loop over rows
                {
                    OutputImage.SetPixel(x, y, Image[x, y]);                // set the pixel color at coordinate (x,y)
                }

            pictureBox2.Image = (Image)OutputImage;                         // display output image
        }

        // A button to do both the pre-processing and the classification in one go.
        private void preClassifyButtonClick(object sender, EventArgs e)
        {
            if (InputImage == null) return;                                 // get out if no input image
            if (OutputImage != null) OutputImage.Dispose();                 // reset output image
            OutputImage = new Bitmap(InputImage.Size.Width, InputImage.Size.Height); // create new output image
            Color[,] Image = new Color[InputImage.Size.Width, InputImage.Size.Height]; // create array to speed-up operations (Bitmap functions are very slow)

            // copy input Bitmap to array            
            for (int x = 0; x < InputImage.Size.Width; x++)                 // loop over columns
                for (int y = 0; y < InputImage.Size.Height; y++)            // loop over rows
                {
                    Image[x, y] = InputImage.GetPixel(x, y);                // set pixel color in array at (x,y)
                }

            sbyte[,] hX = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            sbyte[,] hY = { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

            workingImage = convertToGrayscale(Image);
            workingImage = medianFilter(workingImage, Byte.Parse(sizeBox.Text));
            workingImage = sharpenEdges(workingImage, float.Parse(sharpBox.Text), Byte.Parse(smoothSizeBox.Text), float.Parse(smoothBox.Text));
            workingImage = closeImage(workingImage, createStructuringElement(strucShapeCombo.Text.ToLower(), int.Parse(strucSizeBox.Text)));
            workingImage = cannyEdge(workingImage, hX, hY);
            workingImage = thresholdImage(workingImage, Byte.Parse(thresholdField.Text));

            // ColorNoise is based on the slider, if there is a lot of noise the threshold in getColors will be a bigger value 
            float colorNoise = (float)(noiseTrack.Value / 1.5);
            List<Tuple<int, int, int>> circles = circleLocations(workingImage, int.Parse(rMin.Text), int.Parse(rMax.Text), 30, 0.25);
            List<Color> colors = getColors(Image, circles, colorNoise);
            List<List<Tuple<Point, Point>>> boundingBoxes = new List<List<Tuple<Point, Point>>>();

            byte[,] flipImage = convertToGrayscale(Image);
            List<bool> front = new List<bool>();

            int countRed = 0;
            int countBlue = 0;
            int countGreen = 0;
            int countYellow = 0;
            int countBlack = 0;

            foreach (Tuple<int, int, int> t in circles)
            {
                boundingBoxes.Add(createBoundingBox(t));
                front.Add(isFront(flipImage, t));
            }

            foreach (List<Tuple<Point, Point>> l in boundingBoxes)
            {
                int index = boundingBoxes.IndexOf(l);
                Color color = colors[index];
                bool notBack = front[index];

                if (color == Color.Red)
                    countRed++;
                if (color == Color.Blue)
                    countBlue++;
                if (color == Color.YellowGreen)
                    countYellow++;
                if (color == Color.Green)
                    countGreen++;
                if (color == Color.Black)
                    countBlack++;

                foreach (Tuple<Point, Point> t in l)
                {
                    int x1 = t.Item1.X;
                    int y1 = t.Item1.Y;

                    int x2 = t.Item2.X;
                    int y2 = t.Item2.Y;

                    if (x1 != x2)
                        for (int x = x1; x < x2; x++)
                        {
                            try
                            {
                                if (!notBack)
                                {
                                    if (x % 10 > 4 && x % 10 < 9)
                                        for (int y = y1 - 1; y < y1 + 1; y++)
                                            Image[x, y] = color;
                                }
                                else
                                    for (int y = y1 - 1; y < y1 + 1; y++)
                                        Image[x, y] = color;
                            }
                            catch { }
                        }
                    else if (x1 == x2)
                        for (int y = y1; y < y2; y++)
                        {
                            try
                            {
                                if (!notBack)
                                {
                                    if (y % 10 > 4 && y % 10 < 9)
                                        for (int x = x1 - 1; x < x1 + 1; x++)
                                            Image[x, y] = color;
                                }
                                else
                                    for (int x = x1 - 1; x < x1 + 1; x++)
                                        Image[x, y] = color;

                            }
                            catch { }
                        }
                }
            }

            copperCount.Text = $"Found {countRed} 1 or 2 or 5 cent coin(s)";
            goldCount.Text = $"Found {countYellow} 10 or 20 or 50 cent coin(s)";
            countOneEu.Text = $"Found {countBlue} 1 euro coin(s)";
            countTwoEu.Text = $"Found {countGreen} 2 euro coin(s)";
            countUnclassified.Text = $"Found {countBlack} unidentified circle(s)";

            for (int x = 0; x < workingImage.GetLength(0); x++)             // loop over columns
                for (int y = 0; y < workingImage.GetLength(1); y++)         // loop over rows
                {
                    OutputImage.SetPixel(x, y, Image[x, y]);                // set the pixel color at coordinate (x,y)
                }

            pictureBox2.Image = (Image)OutputImage;                         // display output image

        }

        private void noiseTrack_Scroll(object sender, EventArgs e)
        {
            noiseCount.Text = noiseTrack.Value.ToString();
        }

        /*
         * saveButton_Click: process when user clicks "Save" button
         */
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (OutputImage == null) return;                                // get out if no output image
            if (saveImageDialog.ShowDialog() == DialogResult.OK)
                OutputImage.Save(saveImageDialog.FileName);                 // save the output image
        }

        /*
         * convertToGrayScale: convert a three-channel color image to a single channel grayscale image
         * input:   inputImage          three-channel (Color) image
         * output:                      single-channel (byte) image
         */
        private byte[,] convertToGrayscale(Color[,] inputImage)
        {
            // create temporary grayscale image of the same size as input, with a single channel
            byte[,] tempImage = new byte[inputImage.GetLength(0), inputImage.GetLength(1)];

            // setup progress bar
            progressBar.Visible = true;
            progressBar.Minimum = 1;
            progressBar.Maximum = InputImage.Size.Width * InputImage.Size.Height;
            progressBar.Value = 1;
            progressBar.Step = 1;

            // process all pixels in the image
            for (int x = 0; x < InputImage.Size.Width; x++)                 // loop over columns
                for (int y = 0; y < InputImage.Size.Height; y++)            // loop over rows
                {
                    Color pixelColor = inputImage[x, y];                    // get pixel color
                    byte average = (byte)((pixelColor.R + pixelColor.B + pixelColor.G) / 3); // calculate average over the three channels
                    tempImage[x, y] = average;                              // set the new pixel color at coordinate (x,y)
                    progressBar.PerformStep();                              // increment progress bar
                }

            progressBar.Visible = false;                                    // hide progress bar

            return tempImage;
        }


        // ====================================================================
        // ============= YOUR FUNCTIONS FOR ASSIGNMENT 1 GO HERE ==============
        // ====================================================================

        /*
         * invertImage: invert a single channel (grayscale) image
         * input:   inputImage          single-channel (byte) image
         * output:  tempImage           single-channel (byte) image
         */
        private byte[,] invertImage(byte[,] inputImage)
        {
            // create temporary grayscale image
            byte[,] tempImage = new byte[inputImage.GetLength(0), inputImage.GetLength(1)];
            for (int x = 0; x < inputImage.GetLength(0); x++)             // loop over columns
                for (int y = 0; y < inputImage.GetLength(1); y++)         // loop over rows
                {
                    byte invertedPixel = (byte)(255 - inputImage[x, y]);
                    tempImage[x, y] = invertedPixel;
                }

            return tempImage;
        }

        /*
         * createGaussianFilter: create a Gaussian filter of specific square size and with a specified sigma
         * input:   size                length and width of the Gaussian filter (only odd sizes)
         *          sigma               standard deviation of the Gaussian distribution
         * output:  filter              Gaussian filter
         */
        private float[,] createGaussianFilter(byte size, float sigma)
        {
            float[,] filter = new float[size, size];

            if (size % 2 == 1)
            {
                float gaussianSum = 0;
                int filterCenter = (filter.GetLength(0) - 1) / 2;

                for (int x = 0; x < size; x++)
                    for (int y = 0; y < size; y++)
                    {
                        // calculate the Gaussian value for each of the filter points and store them in our filter
                        float distx = filterCenter - x;
                        float disty = filterCenter - y;

                        float gaussianNumber = (float)Math.Pow(Math.E, -(distx * distx + disty * disty) / (2 * (sigma * sigma)));
                        gaussianSum += gaussianNumber;
                        filter[x, y] = gaussianNumber;
                    }

                // normalize values to sum to 1
                for (int x = 0; x < size; x++)
                    for (int y = 0; y < size; y++)
                        filter[x, y] = filter[x, y] / gaussianSum;

            }
            return filter;
        }

        /*
         * convolveImage: apply linear filtering of an input image
         * input:   inputImage          single-channel (byte) image
         *          filter              linear kernel
         * output:  retImage            single-channel (byte) image
         */
        private byte[,] convolveImage(byte[,] inputImage, float[,] filter)
        {
            int paddingSize = (int)Math.Floor((double)filter.GetLength(0) / 2);
            byte[,] tempImage = createPaddedImage(inputImage, (byte)filter.GetLength(0));
            byte[,] retImage = new byte[inputImage.GetLength(0), inputImage.GetLength(1)];

            // Apply filter
            for (int x = paddingSize; x < tempImage.GetLength(0) - paddingSize; x++)
                for (int y = paddingSize; y < tempImage.GetLength(1) - paddingSize; y++)
                {
                    short newValue = 0;
                    for (int i = 0; i < filter.GetLength(0); i++)
                        for (int j = 0; j < filter.GetLength(1); j++)
                            newValue += (short)(filter[i, j] * tempImage[x - paddingSize + i, y - paddingSize + j]);

                    retImage[x - paddingSize, y - paddingSize] = (byte)newValue;
                }

            return retImage;
        }

        /*
         * medianFilter: apply median filtering on an input image with a kernel of specified size
         * input:   inputImage          single-channel (byte) image
         *          size                length/width of the median filter kernel
         * output:  retImage            single-channel (byte) image
         */
        private byte[,] medianFilter(byte[,] inputImage, byte size)
        {
            int paddingSize = (int)Math.Floor((double)size / 2);
            byte[,] tempImage = createPaddedImage(inputImage, size);
            byte[,] retImage = new byte[inputImage.GetLength(0), inputImage.GetLength(1)];

            byte[,] filter;
            byte[] filter1d;

            // Apply filter
            for (int x = paddingSize; x < tempImage.GetLength(0) - paddingSize; x++)
                for (int y = paddingSize; y < tempImage.GetLength(1) - paddingSize; y++)
                {
                    filter = new byte[size, size];
                    filter1d = new byte[size * size];

                    for (int i = 0; i < size; i++)
                        for (int j = 0; j < size; j++)
                            filter[i, j] = tempImage[x - paddingSize + i, y - paddingSize + j];

                    // turn filter into 1d array so we can sort
                    int k = 0;
                    for (int i = 0; i < size; i++)
                        for (int j = 0; j < size; j++)
                            filter1d[k++] = filter[i, j];

                    Array.Sort(filter1d);
                    byte center = (byte)Math.Floor((double)filter1d.Length / 2);

                    if (filter1d.Length % 2 != 0)
                        retImage[x - paddingSize, y - paddingSize] = filter1d[center];
                    else
                        retImage[x - paddingSize, y - paddingSize] = (byte)((filter1d[center] + filter1d[center - 1]) * 0.5);
                }

            return retImage;
        }

        // A function for canny edge detection. This is partly the same as our old edge detection, but with the extra functionality
        // that canny edge detection brings.
        private byte[,] cannyEdge(byte[,] inputImage, sbyte[,] horizontalKernel, sbyte[,] verticalKernel)
        {
            int paddingSize = (int)Math.Floor((double)horizontalKernel.GetLength(0) / 2);
            byte[,] tempImage = createPaddedImage(inputImage, (byte)horizontalKernel.GetLength(0));
            byte[,] retImage = new byte[inputImage.GetLength(0), inputImage.GetLength(1)];

            short[,] tempImageX = new short[tempImage.GetLength(0), tempImage.GetLength(1)];
            short[,] tempImageY = new short[tempImage.GetLength(0), tempImage.GetLength(1)];

            // Calculate Dx(u,v) and Dy(u,v)
            for (int x = paddingSize; x < tempImage.GetLength(0) - paddingSize; x++)
                for (int y = paddingSize; y < tempImage.GetLength(1) - paddingSize; y++)
                {
                    short newValueX = 0;
                    short newValueY = 0;
                    for (int i = 0; i < horizontalKernel.GetLength(0); i++)
                        for (int j = 0; j < verticalKernel.GetLength(0); j++)
                        {
                            newValueX += (short)(horizontalKernel[i, j] * tempImage[x - paddingSize + i, y - paddingSize + j]);
                            newValueY += (short)(verticalKernel[i, j] * tempImage[x - paddingSize + i, y - paddingSize + j]);
                        }

                    tempImageX[x, y] = newValueX;
                    tempImageY[x, y] = newValueY;
                }

            // Calculate the gradient magnitude and the angle
            short maxG = 0;
            short minG = Int16.MaxValue;
            short[,] gradient = new short[inputImage.GetLength(0), inputImage.GetLength(1)];
            double[,] angle = new double[inputImage.GetLength(0), inputImage.GetLength(1)];
            for (int x = 0; x < retImage.GetLength(0); x++)
                for (int y = 0; y < retImage.GetLength(1); y++)
                {
                    angle[x, y] = Math.Atan2(tempImageY[x, y], tempImageX[x, y]);
                    gradient[x, y] = (short)Math.Sqrt((tempImageX[x, y] * tempImageX[x, y]) + (tempImageY[x, y] * tempImageY[x, y]));
                    if (gradient[x, y] > maxG)
                        maxG = gradient[x, y];
                    if (gradient[x, y] < minG)
                        minG = gradient[x, y];
                }

            // Non-maximum suppression.
            for (int x = 1; x < gradient.GetLength(0) - 1; x++)
            {
                for (int y = 1; y < gradient.GetLength(1) - 1; y++)
                {
                    short q = maxG;
                    short r = maxG;

                    if ((angle[x, y] < 22.5 && angle[x, y] >= 0) || (angle[x, y] < 180 && angle[x, y] >= 157.5))
                    {
                        q = gradient[x, y + 1];
                        r = gradient[x, y - 1];
                    }
                    else if (angle[x, y] < 67.5 && angle[x, y] >= 22.5)
                    {
                        q = gradient[x + 1, y - 1];
                        r = gradient[x - 1, y - 1];
                    }
                    else if (angle[x, y] < 112.5 && angle[x, y] >= 67.5)
                    {
                        q = gradient[x + 1, y];
                        r = gradient[x - 1, y];
                    }
                    else if (angle[x, y] < 157.5 && angle[x, y] >= 112.5)
                    {
                        q = gradient[x - 1, y - 1];
                        r = gradient[x + 1, y + 1];
                    }

                    if (gradient[x, y] < q || gradient[x, y] < r)
                    {
                        gradient[x, y] = minG; 
                    }
                }
            }

            // Double thresholding
            double highThreshold = maxG * 0.09;
            double lowThreshold = highThreshold * 0.05;
            short[,] doubleThreshold = new short[gradient.GetLength(0), gradient.GetLength(1)];

            for (int x = 0; x < gradient.GetLength(0); x++)
            {
                for (int y = 0; y < gradient.GetLength(1); y++)
                {
                    if (gradient[x, y] >= lowThreshold && gradient[x, y] <= highThreshold)
                        doubleThreshold[x, y] = -1;
                    else if (gradient[x, y] >= highThreshold)
                        doubleThreshold[x, y] = 1;
                    else if (gradient[x, y] < lowThreshold)
                        doubleThreshold[x, y] = 0;
                }

            }

            // Actually drawing the double thresholded values.
            for (int x = 1; x < gradient.GetLength(0) - 1; x++)
            {
                for (int y = 1; y < gradient.GetLength(1) - 1; y++)
                {
                    if (doubleThreshold[x, y] == -1)
                    {
                        if ((doubleThreshold[x - 1, y] == 1 || doubleThreshold[x + 1, y] == 1 || doubleThreshold[x - 1, y - 1] == 1 || doubleThreshold[x - 1, y + 1] == 1
                            || doubleThreshold[x + 1, y - 1] == 1 || doubleThreshold[x + 1, y + 1] == 1 || doubleThreshold[x, y - 1] == 1 || doubleThreshold[x, y + 1] == 1))
                            gradient[x, y] = gradient[x, y];
                        else
                            gradient[x, y] = minG;
                    }
                }
            }

            // Scale those values back to 0-255 so we can store them in a byte array
            for (int x = 0; x < retImage.GetLength(0); x++)
                for (int y = 0; y < retImage.GetLength(1); y++)
                {
                    gradient[x, y] = (short)(((gradient[x, y] - minG) * 255) / (double)(maxG - minG));
                    retImage[x, y] = (byte)gradient[x, y];
                }

            return retImage;
        }

        /*
         * thresholdImage: threshold a grayscale image
         * input:   inputImage          single-channel (byte) image
         * output:  tempImage           single-channel (byte) image with on/off values
         */
        private byte[,] thresholdImage(byte[,] inputImage, byte threshold)
        {
            // Threshold image
            byte[,] tempImage = new byte[inputImage.GetLength(0), inputImage.GetLength(1)];
            for (int x = 0; x < inputImage.GetLength(0); x++)
                for (int y = 0; y < inputImage.GetLength(1); y++)
                {
                    if (inputImage[x, y] > threshold)
                        tempImage[x, y] = 255;
                    else
                        tempImage[x, y] = 0;
                }

            return tempImage;
        }

        /*
         * sharpenEdges: sharpen the edges of an image
         * input:   inputImage          single-channel (byte) image
         * output:  retImage            single-channel (byte) image with sharpened edges
         */
        private byte[,] sharpenEdges(byte[,] inputImage, float factor, byte filterSize, float filterSigma) //Unsharp masking
        {
            short[,] tempImage = new short[inputImage.GetLength(0), inputImage.GetLength(1)];
            byte[,] retImage = new byte[inputImage.GetLength(0), inputImage.GetLength(1)];
            byte[,] smoothImage = convolveImage(inputImage, createGaussianFilter(filterSize, filterSigma));
            short[,] mask = new short[inputImage.GetLength(0), inputImage.GetLength(1)];

            for (int x = 0; x < inputImage.GetLength(0); x++)
                for (int y = 0; y < inputImage.GetLength(1); y++)
                    mask[x, y] = (short)(inputImage[x, y] - smoothImage[x, y]);

            // Create the new image by subtracting the mask from the original image
            short maxValue = 0;
            short minValue = Int16.MaxValue;
            for (int x = 0; x < inputImage.GetLength(0); x++)
                for (int y = 0; y < inputImage.GetLength(1); y++)
                {
                    tempImage[x, y] = (short)(inputImage[x, y] + factor * mask[x, y]);
                    if (tempImage[x, y] > maxValue)
                        maxValue = tempImage[x, y];
                    if (tempImage[x, y] < minValue)
                        minValue = tempImage[x, y];
                }

            // Scale the values back to the range 0-255
            for (int x = 0; x < inputImage.GetLength(0); x++)
                for (int y = 0; y < inputImage.GetLength(1); y++)
                    retImage[x, y] = (byte)((tempImage[x, y] - minValue) * 255.0 / (maxValue - minValue));

            return retImage;
        }

        // function to add padding to image to apply kernels
        private byte[,] createPaddedImage(byte[,] inputImage, byte size)
        {
            int paddingSize = (int)Math.Floor((double)size / 2);
            byte[,] tempImage = new byte[inputImage.GetLength(0) + 2 * paddingSize, inputImage.GetLength(1) + 2 * paddingSize];

            // Add padding
            for (int x = 0; x < tempImage.GetLength(0); x++)
                for (int y = 0; y < tempImage.GetLength(1); y++)
                {
                    if (x < paddingSize || y < paddingSize || x > paddingSize + inputImage.GetLength(0) - 1 || y > paddingSize + inputImage.GetLength(1) - 1)
                    {
                        // Corners
                        if (x < paddingSize && y < paddingSize)
                            tempImage[x, y] = inputImage[0, 0];
                        else if (x < paddingSize && y >= paddingSize + inputImage.GetLength(1))
                            tempImage[x, y] = inputImage[0, inputImage.GetLength(1) - 1];
                        else if (x >= paddingSize + inputImage.GetLength(0) && y < paddingSize)
                            tempImage[x, y] = inputImage[inputImage.GetLength(0) - 1, 0];
                        else if (x >= paddingSize + inputImage.GetLength(0) && y >= paddingSize + inputImage.GetLength(1))
                            tempImage[x, y] = inputImage[inputImage.GetLength(0) - 1, inputImage.GetLength(1) - 1];

                        // Other edges
                        else if (x >= paddingSize && y < paddingSize && x <= inputImage.GetLength(0) + paddingSize)
                            tempImage[x, y] = inputImage[x - paddingSize, 0];
                        else if (x < paddingSize && y >= paddingSize && y < inputImage.GetLength(1) + paddingSize)
                            tempImage[x, y] = inputImage[0, y - paddingSize];
                        else if (x >= inputImage.GetLength(0) + paddingSize && y >= paddingSize && y < inputImage.GetLength(1) + paddingSize)
                            tempImage[x, y] = inputImage[inputImage.GetLength(0) - 1, y - paddingSize];
                        else if (x >= paddingSize && y >= inputImage.GetLength(1) + paddingSize && x <= inputImage.GetLength(0) + paddingSize)
                            tempImage[x, y] = inputImage[x - paddingSize, inputImage.GetLength(1) - 1];
                    }

                    else
                        tempImage[x, y] = inputImage[x - paddingSize, y - paddingSize];
                }

            return tempImage;
        }

        // ====================================================================
        // ============= YOUR FUNCTIONS FOR ASSIGNMENT 2 GO HERE ==============
        // ====================================================================

        // Function to create a structuring element
        private sbyte[,] createStructuringElement(string shape, int size)
        {
            // If the desired shape is a square, simply fill an array of a set size with 1s.
            if (shape == "square")
            {
                sbyte[,] square = new sbyte[size, size];
                for (int x = 0; x < size; x++)
                    for (int y = 0; y < size; y++)
                        square[x, y] = 1;

                return square;
            }

            // If the desired shape is a plus, only place 1s on the horizontal and vertical center.
            else if (shape == "plus")
            {
                sbyte[,] plus = new sbyte[size, size];
                int center = (int)Math.Floor((double)size / 2);
                for (int x = 0; x < size; x++)
                    for (int y = 0; y < size; y++)
                        if (x == center || y == center)
                            plus[x, y] = 1;

                return plus;
            }

            else if (shape == "circle")
            {
                sbyte[,] circle = new sbyte[size, size];
                int center = (int)Math.Floor((double)size / 2);

                int r = 2;

                for (int x = 0; x < size; x++)
                    for (int y = 0; y < size; y++)
                        if (((x - center) * (x - center) + (y - center) * (y - center)) <= (r * r))
                            circle[x, y] = 1;

                return circle;
            }
            else
                return null;
        }

        // Function to dilate an image.
        private byte[,] dilateImage(byte[,] inputImage, sbyte[,] inputShape)
        {
            // Because we are working with a kernel, we need to add padding to the image.
            byte[,] paddedImage = createPaddedImage(inputImage, (byte)inputShape.GetLength(0));
            short[,] tempImage = new short[inputImage.GetLength(0), inputImage.GetLength(1)];
            byte[,] retImage = new byte[inputImage.GetLength(0), inputImage.GetLength(1)];
            int paddingSize = (int)Math.Floor((double)inputShape.GetLength(0) / 2);

            short maxValue = 0;
            short minValue = short.MaxValue;

            // For every pixel in the padded image (excluding the borders).
            for (int x = paddingSize; x < paddedImage.GetLength(0) - paddingSize; x++)
                for (int y = paddingSize; y < paddedImage.GetLength(1) - paddingSize; y++)
                {
                    // Calculate the diluted values within the kernel shape.
                    short[,] kernelDilated = new short[inputShape.GetLength(0), inputShape.GetLength(1)];

                    for (int i = 0; i < inputShape.GetLength(0); i++)
                        for (int j = 0; j < inputShape.GetLength(1); j++)
                            if (inputShape[i, j] != 0)
                                kernelDilated[i, j] = (short)(inputShape[i, j] + paddedImage[x - paddingSize + i, y - paddingSize + j]);

                    // Find the max value of the values within the kernel shape.
                    short max = 0;

                    for (int i = 0; i < kernelDilated.GetLength(0); i++)
                        for (int j = 0; j < kernelDilated.GetLength(1); j++)
                            if (kernelDilated[i, j] > max)
                                max = kernelDilated[i, j];

                    // Replace our tempImage value with the max value we found in the kernel and calculate the max
                    // value in our image at the same time.
                    tempImage[x - paddingSize, y - paddingSize] = max;

                    if (tempImage[x - paddingSize, y - paddingSize] > maxValue)
                        maxValue = tempImage[x - paddingSize, y - paddingSize];
                    if (tempImage[x - paddingSize, y - paddingSize] < minValue)
                        minValue = tempImage[x - paddingSize, y - paddingSize];
                }

            // Scale our image values back to the range 0-255
            for (int x = 0; x < inputImage.GetLength(0); x++)
                for (int y = 0; y < inputImage.GetLength(1); y++)
                    retImage[x, y] = (byte)((tempImage[x, y] - minValue) * 255.0 / (maxValue - minValue));

            return retImage;
        }

        // A function to erode an image.
        private byte[,] erodeImage(byte[,] inputImage, sbyte[,] inputShape)
        {
            // Eroding an image is the same as taking the mirrored inputShape and applying it to the inverted
            // input image. Since our input shapes are symmetrical, however, we do not need to mirror it (since
            // we can assume that our structuring elements are of (arbitrary) odd size.
            byte[,] tempImage = invertImage(inputImage);
            tempImage = dilateImage(tempImage, inputShape);
            byte[,] retImage = invertImage(tempImage);

            return retImage;
        }

        // Simply dilate and image and erode it by the same input shape.
        private byte[,] closeImage(byte[,] inputImage, sbyte[,] inputShape)
        {
            return erodeImage(dilateImage(inputImage, inputShape), inputShape);
        }

        // =======================================================
        // ============= Circle Detection Functions ==============
        // =======================================================

        // General function to detect circles using the Hough Circle Transform.
        private byte[,] circleDetection(byte[,] inputImage, int rmin, int rmax, double steps, double threshold)
        {
            // We create a list of possible points, where the first and second items in the tuple describe the center point and the third the radius.
            List<Tuple<int, int, int>> points = new List<Tuple<int, int, int>>();
            for (int r = rmin; r < rmax; r++)
                for (int t = 0; t < steps; t++)
                    points.Add(new Tuple<int, int, int>(r, (int)(r * Math.Cos(2 * Math.PI * t / steps)), (int)(r * Math.Sin(2 * Math.PI * t / steps))));

            // Create a dictionary to save each point along with a value (the voting).
            Dictionary<Tuple<int, int, int>, int> dict = new Dictionary<Tuple<int, int, int>, int>();
            for (int x = 0; x < inputImage.GetLength(0); x++)
                for (int y = 0; y < inputImage.GetLength(1); y++)
                    if (inputImage[x, y] > 0)
                    {
                        foreach (Tuple<int, int, int> t in points)
                        {
                            int a = x - t.Item2;
                            int b = y - t.Item3;

                            if (dict.ContainsKey(new Tuple<int, int, int>(a, b, t.Item1)))
                            {
                                int score = dict[new Tuple<int, int, int>(a, b, t.Item1)];
                                dict[new Tuple<int, int, int>(a, b, t.Item1)] = score + 1;
                            }
                            else
                            {
                                dict.Add(new Tuple<int, int, int>(a, b, t.Item1), 1);
                            }
                        }
                    }

            // Create a list of circles that we have found. Again, the first and second items in the tuple describe the center point and the third the radius.
            List<Tuple<int, int, int>> circles = new List<Tuple<int, int, int>>();
            foreach (KeyValuePair<Tuple<int, int, int>, int> item in dict)
            {
                int x = item.Key.Item1;
                int y = item.Key.Item2;
                int r = item.Key.Item3;
                double v = item.Value;

                if (v / steps >= threshold)
                {
                    bool forAll = true;
                    foreach (Tuple<int, int, int> waardes in circles)
                        if (!(((x - waardes.Item1) * (x - waardes.Item1) + (y - waardes.Item2) * (y - waardes.Item2)) > (waardes.Item3 * waardes.Item3)))
                        {
                            forAll = false;
                            break;
                        }
                    if (forAll)
                        circles.Add(new Tuple<int, int, int>(x, y, r));
                }
            }

            // This function allows us to draw a gray circle over each of the found circles. We return an altered inputImage, with these overlayed circles.
            foreach (Tuple<int, int, int> coordinates in circles)
            {
                int xo = coordinates.Item1;
                int yo = coordinates.Item2;
                int r = coordinates.Item3;

                int rr = (int)(Math.Pow(r, 2));

                for (int x = 0; x < inputImage.GetLength(0); x++)
                    for (int y = 0; y < inputImage.GetLength(1); y++)
                        if (((x - xo) * (x - xo) + (y - yo) * (y - yo)) <= rr)
                            inputImage[x, y] = 122;
            }
            return inputImage;
        }

        // The same function as before, with the exception that we do not draw the circle, but instead return a list of the circles we have found.
        private List<Tuple<int, int, int>> circleLocations(byte[,] inputImage, int rmin, int rmax, double steps, double threshold)
        {
            List<Tuple<int, int, int>> points = new List<Tuple<int, int, int>>();
            for (int r = rmin; r < rmax; r++)
                for (int t = 0; t < steps; t++)
                    points.Add(new Tuple<int, int, int>(r, (int)(r * Math.Cos(2 * Math.PI * t / steps)), (int)(r * Math.Sin(2 * Math.PI * t / steps))));

            Dictionary<Tuple<int, int, int>, int> dict = new Dictionary<Tuple<int, int, int>, int>();

            for (int x = 0; x < inputImage.GetLength(0); x++)
                for (int y = 0; y < inputImage.GetLength(1); y++)
                    if (inputImage[x, y] > 0)
                    {
                        foreach (Tuple<int, int, int> t in points)
                        {
                            int a = x - t.Item2;
                            int b = y - t.Item3;

                            if (dict.ContainsKey(new Tuple<int, int, int>(a, b, t.Item1)))
                            {
                                int score = dict[new Tuple<int, int, int>(a, b, t.Item1)];
                                dict[new Tuple<int, int, int>(a, b, t.Item1)] = score + 1;
                            }
                            else
                            {
                                dict.Add(new Tuple<int, int, int>(a, b, t.Item1), 1);
                            }
                        }
                    }

            List<Tuple<int, int, int>> circles = new List<Tuple<int, int, int>>();

            foreach (KeyValuePair<Tuple<int, int, int>, int> item in dict)
            {
                int x = item.Key.Item1;
                int y = item.Key.Item2;
                int r = item.Key.Item3;
                double v = item.Value;

                if (v / steps >= threshold)
                {
                    bool forAll = true;
                    foreach (Tuple<int, int, int> waardes in circles)
                        if (!(((x - waardes.Item1) * (x - waardes.Item1) + (y - waardes.Item2) * (y - waardes.Item2)) > (waardes.Item3 * waardes.Item3)))
                        {
                            forAll = false;
                            break;
                        }
                    if (forAll)
                        circles.Add(new Tuple<int, int, int>(x, y, r));
                }
            }

            return circles;
        }

        // A function to classify the different types of coins using their colors.
        private string coinClassification(Color coinCenter, int threshold)
        {
            // Describe some "ideal" coin color values.
            Color copper = Color.FromArgb(255, 245, 220, 200);
            Color gold = Color.FromArgb(255, 210, 185, 130);
            Color oneEuInner = Color.FromArgb(255, 217, 217, 217);

            int cDist = int.MaxValue;
            int gDist = int.MaxValue;
            int oDist = int.MaxValue;

            // For each of these, if we find a color that is not too far of from the "ideal color",
            // we return the name of the color that is closest.
            int r = coinCenter.R - copper.R,
                g = coinCenter.G - copper.G,
                b = coinCenter.B - copper.B;
            if ((r * r + g * g + b * b) <= threshold * threshold)
                cDist = r * r + g * g + b * b;
                //return "Copper";

            r = coinCenter.R - gold.R;
            g = coinCenter.G - gold.G;
            b = coinCenter.B - gold.B;

            if ((r * r + g * g + b * b) <= threshold * threshold)
                gDist = r * r + g * g + b * b;
            //return "Gold";

            r = coinCenter.R - oneEuInner.R;
            g = coinCenter.G - oneEuInner.G;
            b = coinCenter.B - oneEuInner.B;

            if ((r * r + g * g + b * b) <= threshold * threshold)
                oDist = r * r + g * g + b * b;
            //return "1 Euro";

            if (cDist < oDist && cDist < gDist)
                return "Copper";
            else if (gDist < oDist && gDist < cDist)
                return "Gold";
            else if (oDist < cDist && oDist < gDist)
                return "1 Euro";

            return "undefined";
        }

        // As can be noticed, there is no 2 Euro classification in the previous function. That is because for that
        // we also want to consider a color that is on the outer edges of the coin.
        private string coinClassification(Color coinCenter, Color coinOuter, int threshold)
        {
            Color twoEuOuter = Color.FromArgb(255, 200, 200, 200);
            Color twoEuInner = Color.FromArgb(255, 230, 209, 164);

            int r = coinCenter.R - twoEuInner.R,
                g = coinCenter.G - twoEuInner.G,
                b = coinCenter.B - twoEuInner.B;

            int r2 = coinOuter.R - twoEuOuter.R,
                g2 = coinOuter.G - twoEuOuter.G,
                b2 = coinOuter.B - twoEuOuter.B;

            if ((r * r + g * g + b * b) <= threshold * threshold)
                if ((r2 * r2 + g2 * g2 + b2 * b2) <= threshold * threshold)
                    return "2 Euro";

            return "undefined";
        }

        // A function to return a list of colors that we have found in circles.
        private List<Color> getColors(Color[,] originalImage, List<Tuple<int, int, int>> circles, float noise)
        {
            List<Color> returnList = new List<Color>();

            foreach (Tuple<int, int, int> coordinates in circles)
            {
                int xo = coordinates.Item1;
                int yo = coordinates.Item2;
                int r = coordinates.Item3;

                // We use a threshold to detect how far off a color is allowed to be to still be classified as a
                // certain color. Because coins are metallic, they can reflect a lot of light, but also get very
                // dirty. That's why we implemented a slider to indicate how much color noise there is on a coin.
                // This affects the color threshold.
                int threshold = 40 + (int)(40 * noise);

                // These are the colors for the bounding boxes.
                Color copper = Color.Red;
                Color gold = Color.YellowGreen;
                Color oneEuInner = Color.Blue;
                Color twoEuInner = Color.Green;

                Color rgbAtOriginal = originalImage[xo, yo];
                Color rgbAtUpper = originalImage[xo, (int)(yo - 0.9 * r)];

                string twoClass = coinClassification(rgbAtOriginal, rgbAtUpper, threshold);
                string classi = coinClassification(rgbAtOriginal, threshold);

                if (twoClass == "2 Euro")
                    returnList.Add(twoEuInner);
                else if (classi == "1 Euro")
                    returnList.Add(oneEuInner);
                else if (classi == "Copper")
                    returnList.Add(copper);
                else if (classi == "Gold")
                    returnList.Add(gold);
                // This means that we have found a circle, but do not know whether it is a coin, or
                // what kind of coin it might be.
                else
                    returnList.Add(Color.Black);
            }

            return returnList;
        }

        // A function to also distinguish the front and the back of a coin.
        private bool isFront(byte[,] inputImage, Tuple<int, int, int> circle)
        {
            // We process the inputImage again, but with different settings. We want there to be a lot of
            // details in the image. So, as many edges as we can find (without there being too much noise).
            sbyte[,] hX = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            sbyte[,] hY = { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

            inputImage = medianFilter(inputImage, 3);
            inputImage = sharpenEdges(inputImage, 3, 5, 8);
            inputImage = cannyEdge(inputImage, hX, hY);
            inputImage = thresholdImage(inputImage, 0);

            int xo = circle.Item1;
            int yo = circle.Item2;
            int r = circle.Item3;
            int rr = (int)(Math.Pow(r, 2));

            // What we want to do is count how many of the pixels inside the circle we found are foreground
            // pixels. What we noticed, was that the percentage of foreground pixels on the front of coins
            // was usually the same. So, we classify a coin as front-facing, when the amount of foreground
            // pixels is within a certain threshold. Otherwise, we classify it as back-facing.
            int countForeground = 0;
            for (int x = 0; x < inputImage.GetLength(0); x++)
                for (int y = 0; y < inputImage.GetLength(1); y++)
                    if (((x - xo) * (x - xo) + (y - yo) * (y - yo)) <= rr)
                    {
                        if (inputImage[x, y] > 0)
                            countForeground++;
                    }

            int surfaceArea = (int)(Math.PI * rr);

            if ((double)countForeground / surfaceArea < 0.11 && (double)countForeground / surfaceArea > 0.0825)
                return true;

            return false;
        }

        // A simple function to create the 4 extreme points for a bounding box of a circle.
        private List<Tuple<Point, Point>> createBoundingBox(Tuple<int, int, int> circle)
        {
            int x1 = circle.Item1 - circle.Item3;
            int x2 = circle.Item1 + circle.Item3;
            int y1 = circle.Item2 - circle.Item3;
            int y2 = circle.Item2 + circle.Item3;

            // x1, y1 -> x2, y1
            // x1, y1 -> x1, y2
            // x1, y2 -> x2, y2
            // x2, y1 -> x2, y2

            Point[] extremes = { new Point(x1, y1), new Point(x2, y1), new Point(x1, y2), new Point(x2, y2) };

            List<Tuple<Point, Point>> retval = new List<Tuple<Point, Point>>();
            retval.Add(new Tuple<Point, Point>(extremes[0], extremes[1]));
            retval.Add(new Tuple<Point, Point>(extremes[0], extremes[2]));
            retval.Add(new Tuple<Point, Point>(extremes[2], extremes[3]));
            retval.Add(new Tuple<Point, Point>(extremes[1], extremes[3]));

            return retval;
        }
    }
}


