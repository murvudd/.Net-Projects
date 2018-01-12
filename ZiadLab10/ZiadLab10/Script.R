# definicja funkcji
{
    Initialize <- function(Nc, Nr, Rn, Nk) {
        Ncolumns <- Nc;#const
        Nrows  <- Nr;#iloœæ pnktów w danych
        range <- Rn ;# max zakres danych
        k <- Nk;
    }

    EucDist <- function(x, y) { return(sqrt((x[1] - y[1]) ^ 2 + (x[2] - y[2]) ^ 2)) }
    # Odleg³oœæ Euklidesowa
    #x i y jako wiersz macierzy n x 2
    #tutaj x dane   y centroidy

    CentEucDist <- function(x, y) {    #macierz odleg³oœci euclidesowej miêdzy x dane  y œrodki  gdzie x[i,] i y[j,] to vec[2]
        mat = matrix(0, nrow = length(x[, 1]), ncol = length(y[, 1]));
        for (i in 1:length(x[, 1])) {
            for (j in 1:length(y[, 1])) {
                mat[i, j] = EucDist(x[i,], y[j,])
            }
        }
        return(mat)
    }

    KMeansCluster <- function(x, y) { # przypisanie na podstawie min odleg³oœci do clustera 
        v <- c(0);
        for (i in 1:length(x[, 1])) {
            v[i] <- which.min(CentEucDist(x, y)[i,])
        }
        return(v)
    }

    Plot <- function(x, y) {
        plot(x[, 1], x[, 2], type = "p", ylim = c(-range, range), xlim = c(-range, range))
        points(y[, 1], y[, 2], pch = 3, col = 2)

    }

    ColorPlot <- function(x, y) {
        plot(x[, 1], x[, 2], type = "p", ylim = c(-range, range), xlim = c(-range, range))
        for (i in 1:max(x[, 3])) {
            points(y[i, 1], y[i, 2], pch = 3, col = i);
            points(x[which(x[, 3] == i), 1], x[x[, 3] == i, 2], pch = 1, col = i)
        }
    }

    NewKCentroid <- function(x, y) {
        mat <- matrix(0, nrow = max(x[, 3]), ncol = 2)
        for (l in 1:max(x[, 3])) {
            mat[l,] = c(mean(x[which(x[, 3] == l), 1]), mean(x[which(x[, 3] == l), 2]))
        }
        return(mat)
    }

    ProdOfVec <- function(y) {
        x <- as.vector(y)
        l <- length(x)
        s = 1
        for (i in 1:l) {
            s = s * x[i]
        }
        return(s == T)
    }



    StartKMeans <- function(x, dane, œrodki) {
        k = length(œrodki[, 1]);
        for (i in 1:x) {
            if (ProdOfVec(Kcenters == NewKCentroid(Data, Kcenters)) == T) { print("Gotowe!"); break; }
            ColorPlot(Data, Kcenters)
            Kcenters<- NewKCentroid(Data, Kcenters)
            Data[, 3] = KMeansCluster(Data[, 1:2], Kcenters)
            print(i);
            #Sys.sleep(1)
        }
    }

    PopulateDataKMeans <- function() { #x = dane[,1:2]
        Data[,1:2] <- c(sample(-range:range, 2 * Nrows, replace = T));
    }
    

}

Ncolumns = 3; #const
Nrows = 200; #iloœæ pnktów w danych
range = 1000; # max zakres danych
k = 7;
Initialize(3);

Data <- matrix(0, ncol = Ncolumns, nrow = Nrows)
PopulateDataKMeans();
#dane[, 1:2] = c(sample(-range:range, (Ncolumns - 1) * Nrows, replace = T))
Kcenters= matrix(c(sample(-range:range, 2 * k)), ncol = 2, nrow = k);
Data[, 3] = KMeansCluster(Data[, 1:2], Kcenters)
Plot(Data, Kcenters)
ColorPlot(Data, Kcenters)
Kcenters

for (i in 1:50) { if (ProdOfVec(Kcenters == NewCentroid(dane, Kcenters)) == T) { print("Gotowe!"); break; }; ColorPlot(dane, Kcenters); Kcenters<- NewCentroid(dane, Kcenters); dane[, 3] = Cluster(dane[, 1:2], Kcenters); print(i); }
Start(50,dane,Kcenters)