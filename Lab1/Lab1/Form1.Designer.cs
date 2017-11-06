namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nonlinearNormalization = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.gaussianFilterTrackBar = new System.Windows.Forms.TrackBar();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Projection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nonlinearNormalization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaussianFilterTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1044, 39);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "grey";
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.greyClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1149, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "negative";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.negativeClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1044, 91);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(67, 26);
            this.button3.TabIndex = 3;
            this.button3.Text = "original";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.originalClick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1149, 91);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(31, 29);
            this.button4.TabIndex = 4;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1188, 91);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(28, 29);
            this.button5.TabIndex = 5;
            this.button5.Text = "-";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(1063, 154);
            this.trackBar1.Maximum = 256;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(153, 56);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            this.trackBar1.DragDrop += new System.Windows.Forms.DragEventHandler(this.trackBar1_DragDrop);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Lab1.Properties.Resources.lena_condec;
            this.pictureBox1.Location = new System.Drawing.Point(249, 26);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 512);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.Image_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1110, 295);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(67, 26);
            this.button6.TabIndex = 9;
            this.button6.Text = "Histogram";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Histogram_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1110, 327);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(67, 27);
            this.button7.TabIndex = 10;
            this.button7.Text = "Normalization";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(1069, 474);
            this.trackBar2.Maximum = 255;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(153, 56);
            this.trackBar2.TabIndex = 11;
            this.trackBar2.ValueChanged += new System.EventHandler(this.TrashHolding);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1066, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "linear contrast edition";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1054, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "nonlinear contrast edition";
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(1069, 233);
            this.trackBar3.Maximum = 256;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(153, 56);
            this.trackBar3.TabIndex = 14;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            this.trackBar3.ValueChanged += new System.EventHandler(this.nonlinearContrastEdition);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1107, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Binarization";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1061, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "nonlinear normalization";
            // 
            // nonlinearNormalization
            // 
            this.nonlinearNormalization.Location = new System.Drawing.Point(1069, 377);
            this.nonlinearNormalization.Name = "nonlinearNormalization";
            this.nonlinearNormalization.Size = new System.Drawing.Size(153, 56);
            this.nonlinearNormalization.TabIndex = 17;
            this.nonlinearNormalization.ValueChanged += new System.EventHandler(this.nonlinearNormalization_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1090, 533);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Gaussian filter";
            // 
            // gaussianFilterTrackBar
            // 
            this.gaussianFilterTrackBar.Location = new System.Drawing.Point(1069, 565);
            this.gaussianFilterTrackBar.Maximum = 4;
            this.gaussianFilterTrackBar.Name = "gaussianFilterTrackBar";
            this.gaussianFilterTrackBar.Size = new System.Drawing.Size(141, 56);
            this.gaussianFilterTrackBar.TabIndex = 19;
            this.gaussianFilterTrackBar.Value = 1;
            this.gaussianFilterTrackBar.ValueChanged += new System.EventHandler(this.gaussianFilterTrackBar_ValueChanged);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(900, 44);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(117, 23);
            this.button8.TabIndex = 20;
            this.button8.Text = "Edge detection";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.EdgeDetectionEvent);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(900, 93);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 21;
            this.button9.Text = "Laplacian";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.LaplacianClick);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(905, 150);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(111, 30);
            this.button10.TabIndex = 22;
            this.button10.Text = "Equalization";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Equalization_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Projection
            // 
            this.Projection.Location = new System.Drawing.Point(900, 213);
            this.Projection.Name = "Projection";
            this.Projection.Size = new System.Drawing.Size(115, 31);
            this.Projection.TabIndex = 23;
            this.Projection.Text = "Projection";
            this.Projection.UseVisualStyleBackColor = true;
            this.Projection.Click += new System.EventHandler(this.Projection_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 650);
            this.Controls.Add(this.Projection);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.gaussianFilterTrackBar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nonlinearNormalization);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nonlinearNormalization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaussianFilterTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar nonlinearNormalization;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar gaussianFilterTrackBar;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Projection;
    }
}

