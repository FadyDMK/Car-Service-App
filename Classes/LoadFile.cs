using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Service_App
{
    public class LoadFile
    {
        public List<Work> LoadFileMenu(List<Work> works)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {


                    try
                    {
                        //Get the path of specified file
                        string filePath = openFileDialog.FileName;

                        Loader l = new Loader();


                        works = l.LoadFile<Work>(filePath);


                        openFileDialog.Dispose();
                        if (works.Count == 0)
                        {
                            MessageBox.Show("File is Empty Please choose another File ! ", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            works.Clear();
                            return works;
                        }
                        else
                        {
                            MessageBox.Show("The File Has Loaded Successfully!", "Done", MessageBoxButtons.OK);
                            return works;

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        works.Clear();
                        return works;
                    }

                }
                else
                {
                    works.Clear();
                    return works;
                }
            }
        }
    }
    }

