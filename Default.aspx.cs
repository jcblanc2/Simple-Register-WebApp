using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Name: John Clayton Blanc
/// Date: 10/28/2022
/// Course: C#
/// </summary>

namespace devoir_3
{
    public partial class Default : System.Web.UI.Page
    {
        List<Personne> personnes = new List<Personne>();

        protected void Page_Load(object sender, EventArgs e)
        {
            DatabasePersonne.createDatabase();
            displayData();

            txtNom.Focus();

        }



        protected void btnSauvegarder_Click(object sender, EventArgs e)
        {
            // Get data
            string nom = txtNom.Text;
            string prenom1 = txtPrenom1.Text;
            string prenom2 = txtPrenom2.Text;
            string age = txtAge.Text;
            string nationalite = txtNationalite.Text;
            string adresseRue = txtAdresseRue.Text;
            string ville = txtVille.Text;
            string pays = txtPays.Text;
            string telephone = txtTelephone.Text;

            // Check if all data are in the right format
            if (!isDigit(age) || !isDigit(telephone) || !isAlpha(nom) || !isAlpha(prenom1) || !isAlpha(prenom2)
                || !isAlpha(nationalite) || !isAlpha(ville) || !isAlpha(pays))
            {
                messageErrorNotDigit(isDigit(age), "Age");
                messageErrorNotDigit(isDigit(telephone), "Téléphone");
                messageErrorNotLetter(isAlpha(nom), "Nom");
                messageErrorNotLetter(isAlpha(prenom1), "Prénom1");
                messageErrorNotLetter(isAlpha(prenom2), "Prénom2");
                messageErrorNotLetter(isAlpha(nationalite), "Nationalité");
                messageErrorNotLetter(isAlpha(ville), "Ville");
                messageErrorNotLetter(isAlpha(pays), "Pays");
            }
            else if (!check())
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Only prenom2 can be empty";
            }
            else
            {
                lblMessage.Visible = false;

                int Age = int.Parse(age);
                DateTime now = DateTime.Now;
                string date = String.Format("{0}/{1}/{2}", now.Day, now.Month, now.Year);

                Personne personne = new Personne(nom, prenom1, prenom2, Age, nationalite, adresseRue, ville, pays, telephone, date);
                personnes.Add(personne);

                DatabasePersonne.InsertToDatabase(personne);
                displayData();
            }
        }



        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            txtNom.Text = String.Empty;
            txtPrenom1.Text = String.Empty;
            txtPrenom2.Text = String.Empty;
            txtAge.Text = String.Empty;
            txtNationalite.Text = String.Empty;
            txtVille.Text = String.Empty;
            txtPays.Text = String.Empty;
            txtTelephone.Text = String.Empty;
            txtAdresseRue.Text = String.Empty;
        }



        private void displayData()
        {
            DataTable dataTable = DatabasePersonne.GetData();
            if (dataTable.Rows.Count > 0)
            {
                gvPersonne.DataSource = dataTable;
                gvPersonne.DataBind();

                gvPersonne.DataSource = dataTable;
                gvPersonne.DataBind();
            }
            else
            {
                dataTable.Rows.Add(dataTable.NewRow());
                gvPersonne.DataSource = dataTable;
                gvPersonne.DataBind();
            }
        }



        /// <summary>
        /// This method check if all TextBox is not empty to enable the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool check()
        {
            bool checkNom = txtNom.Text.Trim() != String.Empty;
            bool checkPrenom1 = txtPrenom1.Text.Trim() != String.Empty;
            bool checkAge = txtAge.Text.Trim() != String.Empty;
            bool checkNatinalite = txtNationalite.Text.Trim() != String.Empty;
            bool checkAdresse = txtAdresseRue.Text.Trim() != String.Empty;
            bool checkVille = txtVille.Text.Trim() != String.Empty;
            bool checkPays = txtPays.Text.Trim() != String.Empty;
            bool checkTelephone = txtTelephone.Text.Trim() != String.Empty;

            if (checkNom && checkPrenom1 && checkAge && checkNatinalite && checkAdresse &&
                checkVille && checkPays && checkTelephone)
            {
                return true;
            }
            return false;
        }



        /// <summary>
        /// Methode to check if a string contain only letter
        /// </summary>
        /// <param name="chaine"></param>
        /// <returns></returns>
        private bool isAlpha(string chaine)
        {
            return chaine.All(c => !Char.IsDigit(c));

        }



        /// <summary>
        ///  Methode to check if a string contain only digit
        /// </summary>
        /// <param name="chaine"></param>
        /// <returns></returns>
        private bool isDigit(string chaine)
        {
            return chaine.All(c => !Char.IsLetter(c));
        }



        /// <summary>
        /// Method to show a massage on the screen 
        /// if age or telephone don't have only digit
        /// </summary>
        /// <param name="val"></param>
        /// <param name="nameComponent"></param>
        private void messageErrorNotDigit(bool val, string nameComponent)
        {
            if (!val)
            {
                lblMessage.Visible = true;
                lblMessage.Text = $"Only digit for {nameComponent}";
            }
        }



        /// <summary>
        /// Method to show a massage on the screen 
        /// if nom, prenom ... don't have only letter
        /// </summary>
        /// <param name="val"></param>
        /// <param name="nameComponent"></param>
        private void messageErrorNotLetter(bool val, string nameComponent)
        {
            if (!val)
            {
                lblMessage.Visible = true;
                lblMessage.Text = $"{nameComponent} must contain only letters";
            }
        }

    }
}
