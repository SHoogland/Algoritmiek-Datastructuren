using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderBrowser {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            startTreeView();
        }

        private void startTreeView() {

            //Loop through all drives
            foreach (DriveInfo d in DriveInfo.GetDrives()) {
                if (d.IsReady == true) {

                    TreeNode drive = new TreeNode(d.Name);

                    //decide on icon to use for the drive treeNode
                    if (d.DriveType == DriveType.CDRom) {
                        drive.ImageIndex = 1;
                        drive.SelectedImageIndex = 1;
                    }
                    else if (d.DriveType == DriveType.Network) {
                        drive.ImageIndex = 2;
                        drive.SelectedImageIndex = 2;
                    }
                    else {
                        drive.ImageIndex = 0;
                        drive.SelectedImageIndex = 0;
                    }

                    var dirNode = addFoldersAndFiles(drive, d.Name, 1);
                    treeView.Nodes.Add(dirNode);
                }
            }
        }

        private TreeNode addFoldersAndFiles(TreeNode node, string fullName, int depth) {
            //set how deep the program searches through the file system
            if (depth < 4) {
                depth++;
                try {
                    DirectoryInfo parentDir = new DirectoryInfo(fullName);
                    foreach (var dir in parentDir.GetDirectories()) {
                        TreeNode childNode = new TreeNode(dir.Name, 3, 3);
                        var dirNode = addFoldersAndFiles(childNode, fullName + "\\" + dir.Name, depth);
                        node.Nodes.Add(dirNode);
                    }
                    foreach (var file in parentDir.GetFiles()) {
                        node.Nodes.Add(file.Name, file.Name, 4, 4);
                    }
                }
                catch { }
            }
            return node;
        }
    }
}
