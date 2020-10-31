using System;
using UnityEngine;

namespace com.severgames.lib.network
{
    public class VectorPull
    {
        private Vector2[] vectors;
        private int count;
        private String poradok;
        private String temp;
        private int num;

        public void add(float x, float y)
        {
            add(new Vector2(x, y));
        }
        public VectorPull()
        {
            vectors = new Vector2[10];
            for(int i=0;i<10;i++){
                vectors[i] = new Vector2(0,0);
            }
            count = 0;
            poradok = "";
        }

        public void add(Vector2 vec)
        {
            vectors[count] = vec;
            poradok += count;
            count++;
            if (count >= 10)
            {
                count = 0;
            }        
        }

        public Vector2 getLast()
        {
            if (poradok.Equals(""))
            {
                return new Vector2(0, 0);
            }
            return vectors[getNum()];
        }

        private int getNum()
        {
            temp = poradok.Substring(1, poradok.Length - 1);
            num = Convert.ToInt32(poradok.Substring(0,1));
            poradok = temp;
            return num;
        }
        
        

    }

}

