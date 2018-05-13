using System;
using System.Collections.Generic;


public class Auto<PLATZHALTER_FUER_FARBE, PLATZHALTER_FUER_TUEREN>
{

    public PLATZHALTER_FUER_TUEREN Tueren;
    public double PS;
    public int Zylinder;

    public double Hubraum;

    public PLATZHALTER_FUER_FARBE Farbe;


}

class Tree<Platzhalter>
{
    public TreeNode<Platzhalter> CreateNode(Platzhalter wert)
    {
      TreeNode<Platzhalter> retvalue =  new TreeNode<Platzhalter>();
      retvalue.Nutzdaten = wert;
      return retvalue;
    }
}

class TreeNode<Platzhalter>
{
    public Platzhalter Nutzdaten;
    public List<TreeNode<Platzhalter>> childrenlist = new List<TreeNode<Platzhalter>>();
    public void AppendChild(TreeNode<Platzhalter> child1)
    {
        childrenlist.Add(child1);
    }
}

namespace L5_Generics
{
    class Program
    {
        static void Main(string[] args)
        {

            var tree = new Tree<String>();
            var root = tree.CreateNode("root");
            var child1 = tree.CreateNode("child1");
            var child2 = tree.CreateNode("child1");
            root.AppendChild(child1);
            root.AppendChild(child2);
            var grand11 = tree.CreateNode("grand11");
            var grand12 = tree.CreateNode("grand12");
            var grand13 = tree.CreateNode("grand13");
            child1.AppendChild(grand11);
            child1.AppendChild(grand12);
            child1.AppendChild(grand13);
            var grand21 = tree.CreateNode("grand21");
            child2.AppendChild(grand21);
           //child1.RemoveChild(grand12);

            //root.PrintTree();




             List<int> meinIntegerContainer = new List<int>();

             meinIntegerContainer.Add(1231);
             meinIntegerContainer.Add(1244);
             meinIntegerContainer.Add(16895);
             meinIntegerContainer.Add(23);
             meinIntegerContainer.Add(2415);
             meinIntegerContainer.Add(245);
             meinIntegerContainer.Add(4627);
             meinIntegerContainer.Add(85);
             meinIntegerContainer.Add(123);
             meinIntegerContainer.Add(90);

             meinIntegerContainer.Add(1);


             int[] meinIntegerArray = new int[10];
             meinIntegerArray[0] = 113135;
             meinIntegerArray[1] = 1244;
             meinIntegerArray[2] = 16895;
             meinIntegerArray[3] = 1321;
             meinIntegerArray[4] = 14;
             meinIntegerArray[5] = 1574;
             meinIntegerArray[6] = 112;
             meinIntegerArray[7] = 176;
             meinIntegerArray[8] = 123;
             meinIntegerArray[9] = 1;

             meinIntegerArray[10] = 1222;


              //Bestellungen
              Auto<string, int> meinAuto = new Auto<string, int>();

              meinAuto.Farbe = "grau";
              meinAuto.PS = 100;
              meinAuto.Zylinder = 4;
              meinAuto.Hubraum = 2.8;

              //Produktion
              Auto<int, double> einanderesAuto = new Auto<int, double>();

              einanderesAuto.Farbe = 1;
              einanderesAuto.PS = 200;
              einanderesAuto.Zylinder = 8;
              einanderesAuto.Hubraum = 7.5;



        }
    }
}
