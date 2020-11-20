using MySql.Data.MySqlClient;
using System;
using MetierTrader;
using System.Collections.Generic;

namespace GestionnaireBDD
{
    public class GstBdd
    {
        private MySqlConnection cnx;
        private MySqlCommand cmd;
        private MySqlDataReader dr;

        // Constructeur
        public GstBdd()
        {
            string chaine = "Server=localhost;Database=bourse;Uid=root;Pwd=";
            cnx = new MySqlConnection(chaine);
            cnx.Open();
        }

        public List<Trader> getAllTraders()
        {
            List<Trader> lesTraders = new List<Trader>();
            cmd = new MySqlCommand("select idTrader, nomTrader from trader", cnx);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Trader t = new Trader(Convert.ToInt16(dr[0].ToString()),dr[1].ToString());
                lesTraders.Add(t);
            }
            dr.Close();
            return lesTraders;
        }
        public List<ActionPerso> getAllActionsByTrader(int numTrader)
        {
            List<ActionPerso> lesActionPerso = new List<ActionPerso>();

            cmd = new MySqlCommand("SELECT numAction ,nomAction, prixAchat ,quantite , quantite*prixAchat from acheter a inner  join action act on a.numAction = act.idAction where numTrader=" +numTrader, cnx);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                ActionPerso actionP = new ActionPerso(Convert.ToInt16(dr[0].ToString()),dr[1].ToString(), Convert.ToDouble(dr[2].ToString()), Convert.ToInt16(dr[3].ToString()), Convert.ToDouble(dr[4].ToString()));
                lesActionPerso.Add(actionP);
            }
            dr.Close();
            return lesActionPerso;
        }
       

        public List<MetierTrader.Action> getAllActionsNonPossedees(int numTrader)
        {
            List<MetierTrader.Action> lesActions = new List<MetierTrader.Action>();
            cmd = new MySqlCommand("select idAction, nomAction from action  where ",cnx);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                MetierTrader.Action act = new MetierTrader.Action(Convert.ToInt16(dr[0].ToString()), dr[1].ToString());
                lesActions.Add(act);
            }
            return lesActions;
        }

        public void SupprimerActionAcheter(int numAction, int numTrader)
        {
            
        }

        public void UpdateQuantite(int numAction, int numTrader, int quantite)
        {
            
        }

        public double getCoursReel(int numAction)
        {
            double courReel = 0;
            cmd = new MySqlCommand("SELECT coursReel from action where idAction = "+numAction, cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            courReel = Convert.ToDouble(dr[0].ToString());
            return 0;
        }
        public void AcheterAction(int numAction, int numTrader, double prix, int quantite)
        {

        }
        public double getTotalPortefeuille(int numTrader)
        {
            double somme = 0;
            cmd = new MySqlCommand("SELECT SUM(prixAchat * quantite) from acheter where numTrader =" + numTrader, cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            somme = Convert.ToDouble(dr[0].ToString());
            dr.Close();
            return somme;
            
        }
    }
}
