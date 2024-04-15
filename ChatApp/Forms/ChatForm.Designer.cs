namespace ChatApp
{
    partial class ChatForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            richTextBox2 = new RichTextBox();
            EnvioMessage = new TextBox();
            label3 = new Label();
            EnviarMessage = new Button();
            Arquivo = new Button();
            Sair = new Button();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 34);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(621, 358);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(123, 15);
            label1.TabIndex = 1;
            label1.Text = "Mensagens Recebidas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(639, 16);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 2;
            label2.Text = "Conectados";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(639, 34);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(130, 403);
            richTextBox2.TabIndex = 3;
            richTextBox2.Text = "";
            richTextBox2.TextChanged += richTextBox2_TextChanged;
            // 
            // EnvioMessage
            // 
            EnvioMessage.Location = new Point(12, 415);
            EnvioMessage.Name = "EnvioMessage";
            EnvioMessage.Size = new Size(621, 23);
            EnvioMessage.TabIndex = 4;
            EnvioMessage.TextChanged += EnvioMessage_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 395);
            label3.Name = "label3";
            label3.Size = new Size(115, 15);
            label3.TabIndex = 5;
            label3.Text = "Envio de mensagens";
            // 
            // EnviarMessage
            // 
            EnviarMessage.Location = new Point(12, 449);
            EnviarMessage.Name = "EnviarMessage";
            EnviarMessage.Size = new Size(75, 23);
            EnviarMessage.TabIndex = 7;
            EnviarMessage.Text = "Enviar";
            EnviarMessage.UseVisualStyleBackColor = true;
            EnviarMessage.Click += EnviarMessage_Click;
            // 
            // Arquivo
            // 
            Arquivo.Location = new Point(90, 449);
            Arquivo.Name = "Arquivo";
            Arquivo.Size = new Size(75, 23);
            Arquivo.TabIndex = 8;
            Arquivo.Text = "Arquivo";
            Arquivo.UseVisualStyleBackColor = true;
            Arquivo.Click += Arquivo_Click;
            // 
            // Sair
            // 
            Sair.Location = new Point(694, 443);
            Sair.Name = "Sair";
            Sair.Size = new Size(75, 23);
            Sair.TabIndex = 9;
            Sair.Text = "Sair";
            Sair.UseVisualStyleBackColor = true;
            Sair.Click += Sair_Click;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 484);
            Controls.Add(Sair);
            Controls.Add(Arquivo);
            Controls.Add(EnviarMessage);
            Controls.Add(label3);
            Controls.Add(EnvioMessage);
            Controls.Add(richTextBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(richTextBox1);
            Name = "ChatForm";
            Text = "Sockets TCP";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private Label label1;
        private Label label2;
        private RichTextBox richTextBox2;
        private TextBox EnvioMessage;
        private Label label3;
        private Button EnviarMessage;
        private Button Arquivo;
        private Button Sair;
    }
}
