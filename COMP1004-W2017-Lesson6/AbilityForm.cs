﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP1004_W2017_Lesson6
{ 
    public partial class AbilityForm : Form
    {
        //Cretae a new Random object
        Random random = new Random();
        private int _health;
        private int _karma;
        private List<TextBox> _abilities;
        public SplashForm PreviousForm = new SplashForm();
        public AbilityForm()
        {
            InitializeComponent();

            //Instantiates a List of Text Boxes
            this._abilities = new List<TextBox>();
            this._initializeAbilities();
        }

        private void _initializeAbilities()
        {            
            this._abilities.Add(FightingTextBox);
            this._abilities.Add(AgilityTextBox);
            this._abilities.Add(StrengthTextBox);
            this._abilities.Add(EnduranceTextBox);
            this._abilities.Add(ReasonTextBox);
            this._abilities.Add(IntuitionTextBox);
            this._abilities.Add(PsycheTextBox);

        }

        /// <summary>
        /// This Method generates a number between 5 and 10
        /// </summary>
        /// <returns>
        /// returns result 
        /// </returns>
        private int _rol5d10()
        {
            int result = 0;

            for (int count = 0; count < 5; count++)
            {
                result += random.Next(1, 11);
            }
            return result;            
        }
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            //initialize health and karma every roll
            this._health = 0;
            this._karma = 0;

            //Iterates through the Textbox List (_abilities)
            for (int ability =0; ability < this._abilities.Count; ability++)
            {               
                //roll 5d10 and assign the values to a temp variable
                int currentRoll = this._rol5d10();

                //if my ability is physical (ability 0 to 3) add to health
                if(ability < 4)
                {
                    this._health += currentRoll;
                }
                else //otherwise add to karma
                {
                    this._karma += currentRoll;
                }

                //assign the current roll to the current ability
                this._abilities[ability].Text = currentRoll.ToString();
            }
            HealthTextBox.Text = this._health.ToString();
            KarmaTextBox.Text = this._karma.ToString();
        }
    }
}
