﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MHWNoChunk
{
    class FileNode : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public List<FileNode> Childern { get; set; }
        public string Icon { get; set; }
        private bool isSelected;
        public string EntireName { get; set; }
        public long Offset { get; set; }
        public long Size { get; set; }
        public int ChunkLoc { get; set; }
        public bool IsFile { get; set; }
        public int ChunkPointer { get; set; }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                setChilrenSelected(value);
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsSelected"));
                }
            }
        }

        public void setChilrenSelected(bool selected)
        {
            foreach (FileNode child in Childern)
            {
                child.IsSelected = selected;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public FileNode()
        {
            Name = "";
            Icon = AppDomain.CurrentDomain.BaseDirectory + "\\file.png";
            Childern = new List<FileNode>();
            IsSelected = false;
            IsFile = false;
        }

        public FileNode(string name)
        {
            Name = name;
            Icon = AppDomain.CurrentDomain.BaseDirectory + "\\file.png";
            Childern = new List<FileNode>();
            IsSelected = false;
            IsFile = false;
        }

        public FileNode(string name, bool isFile)
        {
            Name = name;
            IsFile = isFile;
            if (isFile) Icon = AppDomain.CurrentDomain.BaseDirectory + "\\file.png";
            else Icon = AppDomain.CurrentDomain.BaseDirectory + "\\dir.png";
            Childern = new List<FileNode>();
            IsSelected = false;
        }

        public FileNode(string name, List<FileNode> children)
        {
            Name = name;
            Icon = AppDomain.CurrentDomain.BaseDirectory + "\\file.png";
            Childern = children;
            IsSelected = false;
            IsFile = false;
        }
    }
}
