   M S B A M L   `   `   `  ����W  SSymmetricDS Config Generator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:SymmetricDS_Config_GeneratorSymmetricDS_Config_Generator  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   )    #SymmetricDS_Config_Generator.Router   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:SymmetricDS_Config_Generator     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   3System&clr-namespace:System;assembly=mscorlib  5   	   -   5          � Title$  Router��5
   	   $��216.859��6   $��820.329��6)    � Icon$ loable tech logo.ico��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   $	��350��62     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�6;   .��5      � .+�5   
   �� -   5         ��Name$ label_Copy6��5      $��Route Name :��6%   $
��Left=�6<   $��	10,10,0,0q�6W   $	��Top=�6j   �� 5   
   -   5         ��Name$ button��5      $
��Save��6!   $��	0,0,10,10q�60   $��Right=�6C   $��75��6_   $��32��6j   $��Bottom=�6v   6�   �� 5   
   -   5         ��Name$ txtRoute��5      $��23��6$   $��146,11,10,0q�60    �� TextWrapping$
 Wrap=�6E   $	��Top=�6Y   �� 5   
   -   5        $ 
label_Copy��5      $��Source Node :��6$   $
��Left=�6<   $��	10,44,0,0q�6W   $	��Top=�6j   �� 5   
   -   5        $ label_Copy1��5      $��Target Node :��6%   $
��Left=�6=   $��	10,75,0,0q�6X   $	��Top=�6k   �� 5   
   -   5        	 ��Name$	 cmbTargetNode��5      $��146,75,10,0q�6*   $	��Top=�6?   
 �� SelectedIndex$
 0��6W   .@�5      ��
TARGET��6$   5      �� 5   
   -   5        $	 cmbSourceNode��5      $��146,42,10,0q�6*   $	��Top=�6?   $
 0��6W   .@�5      ��
SOURCE��6$   5      5      5       