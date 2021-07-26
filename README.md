# Coin_Classifier
This program can classify different images of euro coins. These can be any of the 1, 2, 5, 10, 20, 50 cent or 1/2 Euro coins. 
There are 4 different categories of coins, there are the `copper' coins (1, 2, and 5 cents), the `gold' coins (10, 20, and 50 cents), the 1 Euro coin, and the 2 Euro coin. 
There is also a classification between the front and back of the coins. This means that thare are 8 different classes in total, 2 for each category. 

# Pre-processing
Before an image can be classified, it needs to be pre-processed. Pressing the "pre-process" button, will pre-process the loaded image using our recommended settings.
You can also use your own settings, filling them in in the form and pressing the "apply" button.

![Pre-processing](https://github.com/StephanAkkerman/Coin_Classifier/blob/main/screenshots/pre-processing.png)

# Circle classifcation
After pre-proccesing the classification of circles in the image can begin. Here Hough transform is used to find the circles in the image.

![Circle Classification](https://github.com/StephanAkkerman/Coin_Classifier/blob/main/screenshots/circle-classification.png)


# Refinement
Now that the circles have been detected, the classification of coins can take place. A red box represents a copper coin, green for gold coins, blue for 1 Euro coins, and dark green for 2 Euro coins.
A dotted box shows that a coin is upside-down.

![Refinement](https://github.com/StephanAkkerman/Coin_Classifier/blob/main/screenshots/refinement.png)
![2Euro](https://github.com/StephanAkkerman/Coin_Classifier/blob/main/screenshots/2euro-classification.png) 

# Note
In the folder 'images' there are some images which contain the settings necessary to get good classification on the image.
The images have the name of the image followed by "_settings".
For the images in the distractor images folder we have named the images like x_y_z, with x being the minimum radius, y maximum and z the threshold.