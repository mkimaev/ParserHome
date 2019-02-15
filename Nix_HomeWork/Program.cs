using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nix_HomeWork
{
    class Program
    {
        static List<BaseFile> listBaseFiles = new List<BaseFile>();

        static void Main(string[] args)
        {
            string input = @"Text: file.txt(6B); Some string content
Image: img.bmp(19MB); 1920х1080
Text:data.txt(12B); Another string
Text:data1.txt(7B); Yet another string
Movie:logan.2017.mkv(19GB); 1920х1080; 2h12m";
            
            string[] listStrings = input.Split('\n');
            foreach (string file in listStrings)
            {
                CreateNeedInstance(file);

            }
            var setFiles = from f in listBaseFiles
                           group f by f.GroupType;
            foreach (IGrouping<string, BaseFile> item in setFiles)
            {
                Console.WriteLine(item.Key + ":");
                
                    foreach (var file in item)
                    {
                        if (file is TextFile)
                        {
                        Console.WriteLine('\t' + " " + '\t' + file.Name + "." + file.Extension);
                        Console.WriteLine('\t' + "Extension: " + file.Extension);
                        Console.WriteLine('\t' + "Size: " + file.Size);
                        Console.WriteLine('\t' + "Content: " + ((TextFile)file).Content);
                        }

                    else if (file is MovieFile)
                    {
                        Console.WriteLine('\t' + " " + '\t' + file.Name + "." + file.Extension);
                        Console.WriteLine('\t' + "Extension: " + file.Extension);
                        Console.WriteLine('\t' + "Size: " + file.Size);
                        Console.WriteLine('\t' + "Content: " + ((MovieFile)file).Resolution);
                        Console.WriteLine('\t' + "Length: " + ((MovieFile)file).Length);
                    }
                    else if (file is ImageFile)
                        {
                        Console.WriteLine('\t' + " " + '\t' + file.Name + "." + file.Extension);
                        Console.WriteLine('\t' + "Extension: " + file.Extension);
                        Console.WriteLine('\t' + "Size: " + file.Size);
                        Console.WriteLine('\t' + "Resolution: " + ((ImageFile)file).Resolution);
                        }
                        
                }
            }
        }
        static void CreateNeedInstance(string input)
        {
            
            //BaseFile bfile;
            string clearFile = input.TrimStart();
            if (clearFile.StartsWith("Text"))
            {
                string[] properties = clearFile.Trim().Split(':', '.', '(', ')', ';');
                TextFile bfile = new TextFile();
                bfile.GroupType = properties[0];
                bfile.Name = properties[1];
                bfile.Extension = properties[2];
                bfile.Size = properties[3];
                bfile.Content = properties[5]; 
                
                listBaseFiles.Add(bfile);
            }
            else if (clearFile.StartsWith("Image"))
            {
                string[] properties = clearFile.Trim().Split(':', '.', '(', ')', ';');
                ImageFile bfile = new ImageFile();
                bfile.GroupType = properties[0];
                bfile.Name = properties[1];
                bfile.Extension = properties[2];
                bfile.Size = properties[3];
                bfile.Resolution = properties[5];

                listBaseFiles.Add(bfile);
            }
            else if (clearFile.StartsWith("Movie"))
            {
                string[] properties = clearFile.Trim().Split(':', '.', '(', ')', ';');
                MovieFile bfile = new MovieFile();
                bfile.GroupType = properties[0];
                bfile.Name = properties[1]+ "." + properties[2];
                bfile.Extension = properties[3];
                bfile.Size = properties[4];
                bfile.Resolution = properties[6];
                bfile.Length = properties[7];
                listBaseFiles.Add(bfile);
            }
        }

    }

    abstract class BaseFile
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Extension { get; set; }
        public string GroupType { get; set; }

        public BaseFile()
        {
        }

        public abstract void Open();
    }

    class TextFile : BaseFile
    {
        public string Content { get; set; }
        public override void Open()
        {
            //code
        }
    }

    class ImageFile : BaseFile
    {
        public string Resolution { get; set; }
        public override void Open()
        {
            //code
        }
    }
    class MovieFile : ImageFile
    {
        public string Length { get; set; }
        public override void Open()
        {
            //code
        }
    }




}
