using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        if (comboBox1.SelectedIndex<0)  //проверяет, выделен ли элемент в комбосписке
    { 
        MessageBox.Show("No items selected");      //выдает сообщение, если не выделен
    }else {
        Test test=new Test();  //иначесоздаетобъекткласса Test
    // метод 

    getinfo()класса Testсообщает о наличии файла данных
string stest=test.getinfo(); 
if (stest=="OK") 
{
  MessageBox.Show(stest); 
//проверяет наличие рисунка и удаляет текущий рисунок
if (MyImage!=null)      
{  
MyImage.Dispose(); 
} 
//создаетфайловуюпеременнуюдляввода
    StreamReader sr= File.OpenText(test.path
); 
string s="";
// читает строку из файла, имя которого помещено в классовой 
// переменной 
    test.path

    s=sr.ReadLine();  
if (s!=null) 
{
//преобразует в подстроку выделенный элемент списка
string s1=comboBox1.SelectedItem.ToString();
//определяет местонахождение данной подстроки в файле
int k= s.IndexOf(s1,0,s.Length);
if (k<0)  
{
MessageBox.Show("ComBoItem not Found"); 
goto
 labelfin
; 
}
Библиотека
БГУИР
17
//
определяет позицию 
: 
вслед за именем подстроки
k=s.IndexOf(':',k,s.Length
-k);
if (k<0)  
{
MessageBox.Show(": not found after specified combo Item"); 
goto labelfin; 
}
s=s.Substring(k+1,s.Length-k
-1);
//
определяет
адрес
файла
с
рисунком
k=s.IndexOf(',',0,s.Length); 
if (k>=0) 
{
s=s.Substring(0,k); 
} 
//
добавляет к имени файла пол
ный путь
; 
//
в вашей работе этот оператор следует изменить
s=@"
d
:\msdev
\"+s;  
pictureBox1.SizeMode= PictureBoxSizeMode.StretchImage; 
MyImage
= new
 Bitmap
(s); //
Создает битовый образ картинки из файла
pictureBox1.ClientSize=new Size(120,120);
//
Задает
размеры
картинки
pictureBox1.Image=(Image) MyImage;
//
Преобразует
 BitMap 
в
 Image
labelfin
: ;   
}
} 
else
  //
файл с адресами картинок не существует и он создается
{
MessageBox.Show(stest); 
FileStream fs=File.Create(test.path,1024); 
Byte [] info = new UTF8Encoding(true).GetBytes( 
"Мотоцикл:mot.bmp,
Автомобиль
:avto.bmp,
Трактор
:lorry
.bmp
");
fs.Write
(info
,0,
info
.Length
);//
Занесение информации в файл из буфера
MessageBox.Show("File Created.Repeat then");
}
} 
} 