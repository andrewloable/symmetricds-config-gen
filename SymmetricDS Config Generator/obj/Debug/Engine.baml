   M S B A M L   `   `   `  ����W  SSymmetricDS Config Generator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:SymmetricDS_Config_GeneratorSymmetricDS_Config_Generator  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   )    #SymmetricDS_Config_Generator.Engine   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:SymmetricDS_Config_Generator     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   3System&clr-namespace:System;assembly=mscorlib  5   	   -   5          � Title$  Engine��5
   	   $��409.343��6   $��820.329��6)    � Icon$ loable tech logo.ico��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   $	��350��62     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�6;   .��5      � .+�5   
   �� -   5         ��Name$ label��5      $��Engine Name :��6   $
��Left=�67   $��	10,10,0,0q�6R   $	��Top=�6e   �� 5   
   -   5         ��Name$ txtEngineName��5      $��23��6)   $��190,11,10,0q�65    �� TextWrapping$
 Wrap=�6J   $	��Top=�6^   �� 5   
   -   5        $ 
label_Copy��5      $��Database Driver :��6$   $
��Left=�6@   $��	10,41,0,0q�6[   $	��Top=�6n   �� 5   
   -   5         ��Name$ cmbDatabase��5      $��190,40,10,0q�6(   $	��Top=�6=   	 �� SelectedIndex$	 0��6U   5      �� 5   
   -   5        $ label_Copy1��5      $��JDBC  URL :��6%   $
��Left=�6;   $��	10,72,0,0q�6V   $	��Top=�6i   �� 5   
   -   5        $ 
txtJDBCURL��5      $��23��6&   $��190,73,10,0q�62   $
 Wrap=�6G   $	��Top=�6[   �� 5   
   -   5        $ label_Copy2��5      $��Database User Name :��6%   $
��Left=�6D   $��
10,103,0,0q�6_   $	��Top=�6s   �� 5   
   -	   5        $ label_Copy3��5      $��Database Password :��6%   $
��Left=�6C   $��
10,134,0,0q�6^   $	��Top=�6r   �� 5   
   -
   5        
 ��Name$
 chkIsRootNode��5      $��	Root Node��6*   $
��Left=�6>   $��
19,230,0,0q�6Y   $	��Top=�6m   6�   �� 5   
   -   5        $ 	lblRegURL��5      $��Registration URL :��6#   $
��Left=�6@   $��
10,253,0,0q�6[   $	��Top=�6o   �� 5   
   -   5        $ 
lblSyncURL��5      $��
Sync URL :��6$   $
��Left=�69   $��
10,281,0,0q�6T   $	��Top=�6h   �� 5    
   -   5        $ label_Copy6��5       $��Node Group :��6%   $
��Left=�6<   $��
10,163,0,0q�6W   $	��Top=�6k   �� 5!   
   -   5         ��Name$ btnAdd��5!      $
��Save��6!   $��	0,0,10,10q�60   $��Right=�6C   $��75��6_   $��32��6j   $��Bottom=�6v   6�   �� 5"   
   -   5        $ txtDBUserName��5"      $��23��6)   $��190,103,10,0q�65   $
 Wrap=�6K   $	��Top=�6_   G� 5#   
   -   5         G�Name$ txtDBPassword��5#      $��190,131,10,0q�6-   $	��Top=�6C   �� 5$   
   -   5        $ cmbNodeGroup��5$      $��190,161,10,0q�6)   $	��Top=�6?   $	 0��6W   5%      �� 5&   
   -   5        $ 	txtRegURL��5&      $��23��6%   $��190,256,10,0q�61   $
 Wrap=�6G   $	��Top=�6[   �� 5'   
   -   5        $ 
txtSyncURL��5'      $��23��6&   $��190,284,10,0q�62   $
 Wrap=�6H   $	��Top=�6\   �� 5(   
   -   5        $ label_Copy7��5(      $��External ID :��6%   $
��Left=�6=   $��
10,191,0,0q�6X   $	��Top=�6l   �� 5)   
   -   5        $ txtExternalID��5)      $��23��6)   $��190,194,10,0q�65   $
 Wrap=�6K   $	��Top=�6_   5+      5,      