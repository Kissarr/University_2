using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    
    [Serializable]
    abstract public class Trial//Основной класс испытание
    {
        public string Trial_name { get; set; }
        public int Year { get; set; }
        public int Day { get; set; }
        public int Mounth { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Speciality { get; set; }
        public int Number { get; set; }
    }


    [Serializable]
    public class Exam : Trial//Дочерний класс экзамен, наследует поля от испытания
    {
        public List<string> Questions { get; set; }
        public Int16 Grade { get; set; }
    }
    [Serializable]
    public class Math_exam : Exam//Дочерний класс математика, наследует поля от экзамена
    {
        public int x_min { get; set; }
        public int x_cur { get; set; }
        public void set_x(int div)
        {
            if (x_cur + div > x_max)
            {
                x_cur = x_min + (x_cur + div - x_max);
            }
            else if (x_cur + div < x_min)
            {
                x_cur = x_max - (x_min - x_cur + div);
            }
            else
            {
                x_cur += div;
            }
        }
        public int y_cur { get; set; }
        public void set_y(int div)
        {
            if (y_cur + div > y_max)
            {
                y_cur = y_min + (y_cur + div - y_max);
            }
            else if (y_cur + div < y_min)
            {
                y_cur = y_max - (y_min - y_cur + div);
            }
            else
            {
                y_cur += div;
            }
        }
        public int y_min { get; set; }
        public int x_max { get; set; }
        public int y_max { get; set; }
        public char letter_to_show { get; set; }
        public int velosity { get; set; }
        public string direction { get; set; }
        public Math_exam(int x_min, int x_cur, int y_cur, int y_min, int x_max, int y_max, char letter_to_show, int velosity, string direction)
        {
            this.x_min = x_min;
            this.x_cur = x_cur;
            this.y_cur = y_cur;
            this.y_min = y_min;
            this.x_max = x_max;
            this.y_max = y_max;
            this.letter_to_show = letter_to_show;
            this.velosity = velosity;
            this.direction = direction;
        }
        public void make_step()
        {
            int div = velosity;
            if (direction == "up")
            {
                set_y(div);
            }
            else if (direction == "down")
            {
                set_y(-div);
            }
            else if (direction == "right")
            {
                set_x(div);
            }
            else if (direction == "left")
            {
                set_x(-div);
            }
        }
        public void change_direction(int direct)
        {
            if (direct == 1)
            {
                direction = "up";
            }
            else if (direct == 3)
            {
                direction = "down";
            }
            else if (direct == 2)
            {
                direction = "right";
            }
            else if (direct == 4)
            {
                direction = "left";
            }
        }
    }
    [Serializable]
    public class Prog_exam : Exam//Дочерний класс программирование, наследует поля от экзамена
    {
        public int x_min { get; set; }
        public int x_cur { get; set; }
        public void set_x(int div)
        {
            if(x_cur + div > x_max)
            {
                x_cur = x_max - (x_cur + div - x_max);
                change_direction();
            }
            else if (x_cur + div < x_min)
            {
                x_cur = x_min + (x_min - x_cur + div);
                change_direction();
            }
            else
            {
                x_cur += div;
            }
        } 
        public int y_cur { get; set; }
        public int y_min { get; set; }
        public int x_max { get; set; }
        public int y_max { get; set; }
        public char letter_to_show { get; set; }
        public int velosity { get; set; }
        public string direction { get; set; }
        public Prog_exam(int x_min, int x_cur, int y_cur, int y_min, int x_max, int y_max, char letter_to_show, int velosity, string direction)
        {
            this.x_min = x_min;
            this.x_cur = x_cur;
            this.y_cur = y_cur;
            this.y_min = y_min;
            this.x_max = x_max;
            this.y_max = y_max;
            this.letter_to_show = letter_to_show;
            this.velosity = velosity;
            this.direction = direction;
        }
        public void make_step()
        {
            int div = velosity;
            if (direction == "right")
            {
                set_x(div);
            }
            else if (direction == "left")
            {
                set_x(-div);
            }
        }
        public void change_direction()
        {
            if(direction == "right")
            {
                direction= "left";
            }
            else if (direction == "left")
            {
                direction = "right";
            }
            else
            {
                direction = "right";
            }
        }
    }
}
