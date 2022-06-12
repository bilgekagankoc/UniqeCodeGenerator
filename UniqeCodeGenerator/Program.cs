using System;
using System.Collections.Generic;
using UniqeCodeGenerator.Business;
using UniqeCodeGenerator.DataAccess;
using UniqeCodeGenerator.DataAccess.Entites;
using UniqeCodeGenerator.Models;

namespace UniqeCodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Begin();
            void Begin()
            {
                Console.WriteLine("Kod Oluşturmak için 1'e , Oluşturulan kodu kontrol etmek için 2 ye basınız");
                var choice = Console.ReadKey();
                if (choice.KeyChar == '1')
                {
                    using (UniqeCodeGeneratorContext conn = new UniqeCodeGeneratorContext())
                    {
                        CreateCode cd = new CreateCode();
                        CodeModel cm = new CodeModel();
                        UniqeCode uc = new UniqeCode();
                        List<UniqeCode> uqList = new List<UniqeCode>();
                        for (int i = 0; i < 1000000; i++)
                        {
                            cm.RandomNumber = cd.GenerateRandomNumber(Enums.GeneratorType.Letters);
                            cm.CurrentUniqeCode.Add(cm.CharList[cm.RandomNumber[0]]);
                            cm.RandomNumber = cd.GenerateRandomNumber(Enums.GeneratorType.Number);
                            cm.CurrentUniqeCode.Add(cm.CharList[cm.RandomNumber[0]]);
                            cm.RandomNumber = cd.GenerateRandomNumber(Enums.GeneratorType.Any, 4);
                            foreach (var item in cm.RandomNumber)
                            {
                                cm.CurrentUniqeCode.Add(cm.CharList[item]);
                            }
                            cm.TotalFirstSix = Convert.ToInt32(cm.CurrentUniqeCode[0]) + Convert.ToInt32(cm.CurrentUniqeCode[1]) + Convert.ToInt32(cm.CurrentUniqeCode[2]) + Convert.ToInt32(cm.CurrentUniqeCode[3]) + Convert.ToInt32(cm.CurrentUniqeCode[4]) + Convert.ToInt32(cm.CurrentUniqeCode[5]);
                            cm.CurrentUniqeCode.Add(cm.CharList[cm.TotalFirstSix % 23]);
                            cm.RandomNumber = cd.GenerateRandomNumber(Enums.GeneratorType.ZeroOrTwo);
                            cm.CurrentUniqeCode.Add(cm.CharList[cm.RandomNumber[0]]);
                            if (cm.TotalUniceCodeList.Contains(new string(cm.CurrentUniqeCode.ToArray())))
                            {
                                Console.WriteLine("Duplice yakalandı listeye eklenmedi devam ediliyor" + new string(cm.CurrentUniqeCode.ToArray()));
                                cm.CurrentUniqeCode.Clear();
                                i--;
                                continue;
                            }
                            cm.TotalUniceCodeList.Add(new string(cm.CurrentUniqeCode.ToArray()));
                            cm.CurrentUniqeCode.Clear();
                            Console.WriteLine(i);
                        }
                        foreach (var item in cm.TotalUniceCodeList)
                        {
                            uqList.Add(new UniqeCode()
                            {
                                IsActive = true,
                                Code = item
                            });
                        }
                        conn.UniqeCodes.AddRange(uqList);
                        conn.SaveChanges();
                    }
                }
                else if (choice.KeyChar == '2')
                {
                    Validation vl = new Validation();
                    Console.WriteLine("Kodu Girin");
                    var code = Console.ReadLine();
                    var result = vl.CheckCode(code);
                    if (result)
                    {
                        Console.WriteLine("Geçerli Kod Devam Etmek İçin Bir Tuşa Basın");
                        Begin();
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz Kod Devam Etmek İçin Bir Tuşa Basın");
                        Begin();
                    }

                }
                else
                {
                    Console.WriteLine("Geçersiz bir tuşa bastınız");
                    Console.ReadLine();
                }
            }
        }
    }
}
