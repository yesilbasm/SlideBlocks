# Level Tasarımı yapmak için bir matrix (scriptable Obje) oluşturun ve bu objeyi Levelmanagera yerleştirin.
objenin içini levelprefabs ta bulanan prefabların index değerlerine göre doldurun. yatay blokların pivot noktası en sağdadır ve düşey blokların pivot noktası en aşağıdadır.
eğer marix[0][3] üne 4 birimlik yatay bir blok koyarsanız bu blok matrix in [0][0],[0][1],[0][2],[0][3] deki noktalarını kaplıyacaktır eğer 4 birimlik düşey bir bloğu [3][0]'a
yerleştirirseniz bu matris [3][0],[2][0],[1][0],[0][0] da olan birimleri kaplayacaktır.
buttonlara yerleştireceğiniz birimler yatay olmalıdır.
