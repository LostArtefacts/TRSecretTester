using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TRLevelReader.Helpers;
using TRRandomizerCore.Helpers;

namespace TRSecretTester
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using (CommonOpenFileDialog dlg = new CommonOpenFileDialog())
            {
                dlg.IsFolderPicker = true;
                dlg.Title = "Select Data Folder";
                if (dlg.ShowDialog(Handle) == CommonFileDialogResult.Ok)
                {
                    dataFolderTextBox.Text = dlg.FileName;

                    levelComboBox.Items.Clear();
                    foreach (string file in Directory.GetFiles(dlg.FileName))
                    {
                        string fileName = Path.GetFileName(file).ToUpper();
                        if (TRLevelNames.AsListWithAssault.Contains(fileName))
                        {
                            levelComboBox.Items.AddRange(TRLevelNames.AsListWithAssault.ToArray());
                            levelComboBox.SelectedIndex = 0;
                            addFlaresCheck.Enabled = false;
                            break;
                        }
                        else if (fileName.Equals(TR2LevelNames.HOME))
                        {
                            continue; // ambiguous between TR2/3
                        }
                        else if (TR2LevelNames.AsListWithAssault.Contains(fileName))
                        {
                            levelComboBox.Items.AddRange(TR2LevelNames.AsListWithAssault.ToArray());
                            levelComboBox.SelectedIndex = 0;
                            addFlaresCheck.Enabled = true;
                            break;
                        }
                        else if (TR3LevelNames.AsListWithAssault.Contains(fileName))
                        {
                            levelComboBox.Items.AddRange(TR3LevelNames.AsListWithAssault.ToArray());
                            levelComboBox.SelectedIndex = 0;
                            addFlaresCheck.Enabled = true;
                            break;
                        }
                    }
                }
            }
        }

        private void LaraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            xyzLabel.Enabled = laraPosTextBox.Enabled =
                roomLabel.Enabled = laraRoomSpinner.Enabled = laraCustomPosRadioButton.Checked;
            entityPosSpinner.Enabled = laraEntityPosRadioButton.Checked;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "TR Secret Tester", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void Save()
        {
            doneLabel.Visible = false;

            string dataFolder = dataFolderTextBox.Text.Trim();
            if (dataFolder.Length == 0 || !Directory.Exists(dataFolder))
            {
                throw new IOException("Could not find the given data directory.");
            }

            string lvl = levelComboBox.SelectedItem.ToString();
            if (!File.Exists(Path.Combine(dataFolder, lvl)))
            {
                throw new IOException(string.Format("Could not find {0} in the given data directory.", lvl));
            }

            Positioner.StartPosition startPos;
            Location laraLocation = null;
            if (laraDefaultPosButton.Checked)
            {
                startPos = Positioner.StartPosition.Default;
            }
            else if (laraEntityPosRadioButton.Checked)
            {
                startPos = Positioner.StartPosition.Entity;
            }
            else
            {
                startPos = Positioner.StartPosition.Custom;
            }

            if (laraCustomPosRadioButton.Checked)
            {
                string[] posSplit = laraPosTextBox.Text.Trim().Split(',');
                if (posSplit.Length != 3)
                {
                    throw new ArgumentException(string.Format("Could not parse '{0}' into an [X,Y,Z] position.", laraPosTextBox.Text));
                }

                if (!int.TryParse(posSplit[0].Trim(), out int x))
                {
                    throw new ArgumentException(string.Format("'{0}' is not a valid X position.", posSplit[0]));
                }
                if (!int.TryParse(posSplit[1].Trim(), out int y))
                {
                    throw new ArgumentException(string.Format("{0} is not a valid Y position.", posSplit[1]));
                }
                if (!int.TryParse(posSplit[2].Trim(), out int z))
                {
                    throw new ArgumentException(string.Format("{0} is not a valid Z position.", posSplit[2]));
                }

                laraLocation = new Location
                {
                    X = x,
                    Y = y,
                    Z = z,
                    Room = Convert.ToInt32(laraRoomSpinner.Value)
                };
            }

            Positioner sp = new Positioner
            {
                DataFolder = dataFolder,
                LevelName = lvl,
                LimitEntities = limitEntitiesCheck.Checked,
                EntityLimit = Convert.ToInt32(maxEntitiesSpinner.Value),
                MoveKeyItems = keyItemCheck.Checked,
                MovePuzzleItems = puzzlesCheck.Checked,
                OpenDoors = openDoorsCheck.Checked,
                AddFlares = addFlaresCheck.Enabled && addFlaresCheck.Checked,
                NoEnemy = noEnemyCheck.Checked,
                StartPos = startPos,
                MatchEntityPosition = Convert.ToInt32(entityPosSpinner.Value),
                LaraCustomLocation = laraLocation
            };
            sp.Save();

            doneLabel.Visible = true;
            new Thread(HideLabel).Start();
        }

        private void HideLabel()
        {
            Thread.Sleep(5000);
            Invoke(new Action(() => doneLabel.Visible = false));
        }

        private void LimitEntitiesCheck_CheckedChanged(object sender, EventArgs e)
        {
            maxEntitiesSpinner.Enabled = limitEntitiesCheck.Checked;
        }
    }
}