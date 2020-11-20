using System;
using System.Collections.Generic;
using System.Text;

namespace MetierTrader
{
    public class ActionPerso
    {
        private int numAction;
        private string nomAction;
       
        private double prixAchat;
        private int quantite;
        private double sommePrix;
        public ActionPerso(int unNumA,string unNom, double unPrix,int uneQuantite, double uneSomme)//int unNumT,
        {
            NumAction = unNumA;
            NomAction = unNom;
            //NumTrader = unNumT;
            PrixAchat = unPrix;
            Quantite = uneQuantite;
            SommePrix = uneSomme;

        }
        //public ActionPerso(int unNumA, int unPrix,int uneQuantiteAction, int uneSomme)//, int unNumT
        //{
        //    NumAction = unNumA;
        //    //NumTrader = unNumT;
        //    PrixAchat = unPrix;
        //    Quantite = uneQuantiteAction;
        //    SommePrix = uneSomme;
        //}

        
       
      
      
  
        public int NumAction { get => numAction; set => numAction = value; }
        public int Quantite { get => quantite; set => quantite = value; }
        public double PrixAchat { get => prixAchat; set => prixAchat = value; }
        public string NomAction { get => nomAction; set => nomAction = value; }
        public double SommePrix { get => sommePrix; set => sommePrix = value; }
    }
}
