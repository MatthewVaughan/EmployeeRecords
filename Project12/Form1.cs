using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;
using System.IO;
// File/Project Prolog
// Name: Matthew Vaughan
// CS 1400 Section 003
// Project: Project 12
// Date: 04/21/2016 09:15:19 pm
//
// I declare that the following code was written by me or provided 
// by the instructor for this project. I understand that copying source
// code from any other source constitutes cheating, and that I will receive
// a zero on this project if I am found in violation of this policy.
// ---------------------------------------------------------------------------
namespace Project12
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

        }

        //Declare Constants
        const int
            ZERO = 0,
            ONE = 1,
            TWO = 2,
            THREE = 3,
            FOUR = 4,
            TEN = 10,
            FOURTY = 40;

        //Declare a Global Variable
        int employeeIndex = 0;

        //Declare my array referrencing to employee objects globally
        Employees[] employee = new Employees[10];


        /// <summary>
        /// Previous Button Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            //Decriment employee index
            employeeIndex--;

            //If the employee index goes below zero stop users ability to use the button and add to the index
            if (employeeIndex < 0)
            {
                btnPrev.Enabled = false;
                employeeIndex++;
            }

            //Otherwise keep allowing the user to scroll back through the list
            else
            {
                txtName.Text = ($"{employee[employeeIndex].GetEmployeeName()}");
                txtAddress.Text = ($"{employee[employeeIndex].GetStreetAddress()}");
                txtNetPay.Text = ($"{employee[employeeIndex].GetPay():C2}");

                //Space has opened up to move forward so allow the user to do so
                btnNext.Enabled = true;
            }
        }

        /// <summary>
        /// Next Button Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            //Increment Employee Index
            employeeIndex++;

            //If the employee does NOT return null then allow the user to keep scrolling though
            if (employee[employeeIndex] != null)
            {
                txtName.Text = ($"{employee[employeeIndex].GetEmployeeName()}");
                txtAddress.Text = ($"{employee[employeeIndex].GetStreetAddress()}");
                txtNetPay.Text = ($"{employee[employeeIndex].GetPay():C2}");

                //Space has opened up for the user to go back in the list so allow them to do so
                btnPrev.Enabled = true;
            }

            //Otherwise you have reached the end of the list so hault the users ability to scroll forward and decrement the index
            else
            {
                btnNext.Enabled = false;
                employeeIndex--;
            }
        }

        /// <summary>
        /// Exit Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Close Prpgram
            this.Close();
        }

        /// <summary>
        /// About Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display message box revealing the programmer and the class section
            MessageBox.Show("Matthew Vaughan\nCS1400 Sec 003");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Declare variables
            int index = 0;

            //Declare myStream
            Stream myStream = null;

            //initiate the open dialog as an object
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "text files (*.txt)|*txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Do Not proceed if the open file dialog returns as null
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    //initiate the StreamReader object to read from the file chosen
                    StreamReader data = new StreamReader(myStream);

                    //Declare a string array
                    string[]
                            fileLine = new string[FOURTY],
                            fileSplit = new string[TWO];
                    //Declare a Bool
                    bool
                        test = true;

                    //Create a do while loop to keep on reading in objects
                    do
                    {
                        //Create a nested for loop to gather the information for each object
                        for (int i = 0; i < FOUR; i++)
                        {
                            //if you have reached the 4th line in the object then split it
                            if (i == THREE)
                            {
                                //Save the line read from the file
                                fileLine[i] = data.ReadLine();

                                //Split the line into two values
                                fileSplit = fileLine[i].Split();
                                
                            }
                            //Otherwise the line will not need to be split
                            else
                            {
                                //Save the line read from the file
                                fileLine[i] = data.ReadLine();

                                //If the line returns null break out as you have reached the end of the file
                                if (fileLine[i] == null)
                                {
                                    test = false;
                                    break;
                                }

                            }
                        }

                        //If test is = true, then you have not reached the end so continue saving the data
                        if (test == true)
                        {
                            //Save the data acquired from the file in the object called from the employee class
                            employee[index] = new Employees(int.Parse(fileLine[ZERO]), ($"{fileLine[ONE]}"), ($"{fileLine[TWO]}"), int.Parse(fileSplit[1]), double.Parse(fileSplit[0]));

                            //Increment the index within the while loop
                            index++;
                        }

                        //Otherwise you have reached the end and must break from the loop
                        else
                        {
                            break;
                        }
                    } while (index < TEN);

                    //Fill in the text boxes with the data collected from the first employee in the file
                    txtName.Text = ($"{employee[employeeIndex].GetEmployeeName()}");
                    txtAddress.Text = ($"{employee[employeeIndex].GetStreetAddress()}");
                    txtNetPay.Text = ($"{employee[employeeIndex].GetPay():C2}");

                    //Open the opportunity to click the prev button and the next button
                    if (employee[employeeIndex] != null)
                    {
                        btnNext.Enabled = true;
                        btnPrev.Enabled = true;
                    }
                }
            }
        }
    }
}
