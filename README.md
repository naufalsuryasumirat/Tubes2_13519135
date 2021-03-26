# Tubes2_13519135

i. Penjelasan singkat algoritma BFS dan DFS yang diimplementasikan
BFS yang diimplementasikan merupakan algoritma traversal graf yang memanfaatkan Queque (First In First Out) sebagai
memori untuk urutan traversal graf, awalnya dikunjungi simpul root kemudian seluruh tetangga dari simpul tersebut 
dimasukkan ke dalam Queue tersebut, kemudian simpul yang dikunjungi ditandai sudah dikunjungi dan dilanjutkan ke
elemen pertama dalam Queue, proses kemudian terulang seperti pada simpul root hingga ditemukan simpul tujuan atau
jika sudah tidak terdapat lagi simpul untuk dikunjungi.
DFS yang diimplementasikan merupakan algoritma traversal graf yang memanfaatkan Stack (Last In First Out) sebagai
memori untuk urutan traversal graf, awalnya dikunjungi simpul root kemudian seluruh tetangga dari simpul tersebut
dimasukkan ke dalam Stack, lalu simpul yang dikunjungi ditandai sudah dikunjungi dan dilanjutkan ke Top Of Stack,
proses kemudian berulang seperti pada simpul root secara rekursif hingga tidka terdapat lagi simpul untuk dikunjungi.

ii. Requirement program dan instalasi tertentu bila ada
Untuk kompilasi program, diperlukan Visual Studio 2019 Community Edition dengan fitur .NET Desktop Development.
Program dijalankan pada platform Windows OS x64 dan x86.

iii. Cara menggunakan program
Untuk menggunakan aplikasi yoBOOK, buka folder bin (folder penyimpanan executable yo.exe).
Jalankan program yo.exe, setelah itu tekan tombol Browse untuk memilih file persoalan eksternal.
Setelah dipilih file, pilih akun yang digunakan (Your Account) dan pilih akun yang dituju (Explore Friends)
untuk memulai explore friends, pilih metode traversal (BFS/DFS) dan klik explore.
Animasi akan berjalan, setelah itu jika ingin reset graf, klik tombol reset.
Untuk menggunakan fitur friend recommendation, pilih akun pada Your Account, kemudian tekan tombol mutual friends.
Terdapat fitur Add Account untuk menambah node pada graf (input dari keyboard untuk nama akun).
Terdapat fitur Add Connection untuk menambah edge pada graf.
Tekan tombol minimize untuk me-minimize program, exit untuk keluar dari program.

v. Informasi Tambahan
Source code pada: /src/SocialNetworkApp/SocialNetworkApp
Terdapat 3 file, Classes.cs (Source code kelas-kelas yang digunakan), Form1.cs (GUI, terdapat juga Designer dll),
Program.cs (Main program).

iv. Authors
1. 13519135 - Naufal Alexander Suryasumirat
2. 13519141 - Naufal Yahya Kurnianto
3. 13519161 - Harith Fakhiri Setiawan