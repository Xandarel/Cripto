   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	   H DUserInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:UserInterfaceUserInterface 5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	   P LCryptographicSecurity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:CryptographicSecurity;assembly=CryptographicSecurityCryptographicSecurity 5
         UserInterface.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml    	 5   	   @d2http://schemas.microsoft.com/expression/blend/2008    	 5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006    	 5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf    	 5   	   -localclr-namespace:UserInterface    	 5   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms    	 5   	   3chart!http://schemas.syncfusion.com/wpf    	 5	   	   dcryptographicsecurityBclr-namespace:CryptographicSecurity;assembly=CryptographicSecurity    	 5
        � Title$  Диплом��5   	   $	��450��6   $	��800��6%   .��5      � -   5         �Name$ Grid1��5       � RowDefinitions 5   
   �� 5      $	��250 �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   o� $��25��6   $	��Top=�5      $��3��5      $��
0,0,-0.4,0q�5      .@�5      m� $��Шифрование��6   .@�5      	� -   5         	�Name$ Vishener��5       	� 	GroupName$ encryptionMethod��5      $��Шифр Виженера��5       5!      	� 5"      -   5        $ ReverseVeshener��5"      $ encryptionMethod��5#      $@��:Шифр виженера с обратной связью��5$      5%      	� 5&      -   5        $
 Hill��5&      $ encryptionMethod��5'      $��Шифр Хилла��5(      5)      	� 5*      -   5        $ Permutation��5*      $ encryptionMethod��5+      $'��!Шифр перестановки��5,      5-      5.      m� 50      $��Дешифрование��6   .@�51      	� -   5        $ vishener��51      $ decryptionMethod��52      $��Шифр Виженера��53      54      	� 55      -   5        $ reverseVeshener��55      $ decryptionMethod��56      $@��:Шифр виженера с обратной связью��57      58      	� 59      -   5        $
 hill��59      $ decryptionMethod��5:      $��Шифр Хилла��5;      5<      	� 5=      -	   5        $ permutation��5=      $ decryptionMethod��5>      $'��!Шифр перестановки��5?      5@      5A      m� 5C      $*��$Криптостойкойкость��6   .@�5D      	� -
   5        $ VigenereKey��5F      $ CryptographicSecurity��5D      $��Шифр виженера��5E      5G      	� 5H      -   5        $ FindHillsKey��5J      $ CryptographicSecurity��5H      $��Шифр Хилла��5K      	� 5L      -   5        $ FindPermutationKey��5N      $ CryptographicSecurity��5L      $'��!Шифр перестановки��5O      5P      5R      �� 5T   
    �� Orientation$ Vertical=�6   $��0��5U      $��0��5V      $��3��5W      $��0,0,396.6,0.4q�5X      .+�5Y      �� -   5         ��Name$ TBword��5Y      $
��Left=�5Z      $	��205��5[      $��20,30,171.8,0q�5\      �� 5]      $�
Слово��6   5^      �� 5_      -   5         ��Name$ textBox1��5_      $
��Left=�5`      $	��200��5a      $��	20 10 0 0q�5b      �� 5c      -   5        $ TBkey��5c      $
��Left=�5d      $	��200��5e      $��	20,10,0,0q�5f      �� 5g      $�Ключ��6   5h      �� 5i      -   5        $	 key��5j      $
��Left=�5i      $	��200��5k      $��	20 10 0 0q�5l      	 �� TextWrapping$
	 Wrap=�5m      
 �� AcceptsReturn
 .  �� 
AcceptsTab .  �� 	IsEnabled . 5p      �� 5q      -   5        $ 
ClickTitle��5q      $
��Left=�5r      $	��200��5s      $��	20,10,0,0q�5t      �� 5u      $ 
Horizontal=�6   .+�5v      �� -   5        $ CripDecripBox��5w      $��WrapWithOverflow=�5v      $
��Left=�5x      $	��200��5y      $��	20,10,0,0q�5z      �� 5{      -   5         ��Name$
 Copy��5{      $
��Copy��5|      5}      5~      5      �� 5�   
   -   5         ��Name$ 	Languages��5�      $��0��5�      $��2��5�      $��20.2,30,-0.4,0.4q�5�      .+�5�      	� -   5        $ ru��5�      $
��Left=�5�      $ 	Languages��5�   &   $��Русский��5�       d� 	IsChecked$
 TrueY�5�      $	��100��5�      	� 5�      -   5        $	 eng��5�      $
��Left=�5�      $	��100��5�      $ 	Languages��5�      $��Английский��5�      5�      �� 5�      -   5        $ 
Encryption��5�      $
��Left=�5�      $��	10 10 0 0q�5�      $��Зашифровать��5�      �� 5�      -   5        $ 
Decryption��5�      $
��Left=�5�      $��	10 10 0 0q�5�      $��Расшифровать��5�      �� 5�      -   5        $ KL��5�      $��Размер ключа��6$   $
��Left=�5�      $��	10 10 0 0q�5�      $y�Hidden=�5�      �� 5�      -   5        $��	KeyLength��5�      $
��Left=�5�      $��95��5�      $��	10 10 0 0q�5�       �� SelectedIndex$ 0��5�      $y�Hidden=�5�      .@�5�      �� 
 � Tag$ -1��6   Неизвестно61   �� 5�      $ 2��6   26'   �� 5�      $ 3��6   36'   �� 5�      $ 4��6   46'   �� 5�      $ 5��6   56'   �� 5�      $ 6��6   66'   5�      5�      � 5�   
   $��0��6   $��1��5�       � Orientation$ 
Horizontal=�5�       � 
ItemHeight$ 20��5�       � 	ItemWidth$ 80��5�      $��Center=�6#   .+�5�      �� -   5        $ A��5�      $��A��5�      5�      �� 5�      -   5        $ AA��5�      $��AA��5�      5�      �� 5�      -   5        $	 AAA��5�      $	��AAA��5�      5�      5�      #   LiveCharts.Wpf.CartesianChart  5�   
   -   5          Name$ Table��5�      $��0 20 0 0q�5�      $��0��5�      $��1��5�      &    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Bottom=�5�         Series 5�      �� *SeriesCollection+   AxisX 5�         LiveCharts.Wpf.Axis  -   5          Name$ AxisX��5�   (      Title$
 Word��6      Labels 5�      �� *Labels+5�         AxisY 5�        $ Count��6      LabelFormatter 5�      �� *	Formatter+5�      5�      � 5�   
   $��1��6   $��1��5�      $ 
Horizontal=�5�      $ 20��5�      $ 80��5�      $��Center=�6#   .+�5�      �� -    5        $ A2��5�      $��A��5�      5�      �� 5�      -!   5        $	 AA2��5�      $��AA��5�      5�      �� 5�      -"   5        $
 AAA2��5�      $	��AAA��5�      5�      5�        5�   
   -#   5        $ Table2��5�      $��0 20 0 0q�5�      $��1��5�      $��1��5�      $ Bottom=�5�       5�      �� *SeriesCollection2+ 5�        -$   5        $ AxisX2��5�      $
 Word��5�       5�      �� *	Labels2+5�       5�        $ Count��6    5�      �� *
Formatter2+5�      5�      5�      5�      