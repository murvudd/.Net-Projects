require(numbers);
# definicje funkcji 
{


    EucDist <- function(x, y) { return(sqrt((x[1] - y[1]) ^ 2 + (x[2] - y[2]) ^ 2)) }
    # Odleg³oœæ Euklidesowa
    #x i y jako wiersz macierzy n x 2
    #tutaj x dane   y centroidy

    CentEucDist <- function(x, y) {
        #macierz odleg³oœci euclidesowej miêdzy x dane  y œrodki  gdzie x[i,] i y[j,] to vec[2]
        mat = matrix(0, nrow = length(x[, 1]), ncol = length(y[, 1]));
        for (i in 1:length(x[, 1])) {
            for (j in 1:length(y[, 1])) {
                mat[i, j] = EucDist(x[i,], y[j,])
            }
        }
        return(mat)
    }

    KMeansCluster <- function(x, y) {
        # przypisanie na podstawie min odleg³oœci do oœrodka clustera 
        v <- c(0);
        for (i in 1:length(x[, 1])) {
            v[i] <- which.min(CentEucDist(x, y)[i,])
        }
        return(v)
    }

    Plot <- function(x, y) {
        #x dane, y œrodki
        plot(x[, 1], x[, 2], type = "p", ylim = c(-range, range), xlim = c(-range, range))
        points(y[, 1], y[, 2], pch = 3, col = 2)

    }

    ColorPlot <- function(x, y) {
        plot(x[, 1], x[, 2], type = "p", ylim = c(-range, range), xlim = c(-range, range))
        for (i in 1:k) {
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
            ColorPlot(Data, Kcenters)
            Kcenters <- NewKCentroid(Data, Kcenters)
            Data[, 3] = KMeansCluster(Data[, 1:2], Kcenters)
            print(i);
            if (ProdOfVec(Kcenters == NewKCentroid(Data, Kcenters)) == T) { print("Gotowe!"); break; }
            #Sys.sleep(1)
        }
    }

    PopulateDataKMeans <- function() {
        Dane <- matrix(0, ncol = Ncolumns, nrow = Nrows)
        vec <- matrix(c(sample((-range + 200):(range - 200), 4 * k, replace = T)), ncol = 2, nrow = k)
        for (i in 1:Nrows) {
            Dane[i, 1:2] <- c((sample(-10000:10000, 1) / 50) + vec[mod(i, k) + 1, 1], (sample(-10000:10000, 1) / 50) + vec[mod(i, k) + 1, 2])
        }
        return(Dane)
    }

    PopulateFData <- function() {
        Dane <- matrix(0, ncol = Ncolumns, nrow = Nrows)
        vec <- matrix(c(sample((-range + (percent * range)):(range - (percent * range)), 4 * k, replace = T)), ncol = 2, nrow = k)
        for (i in 1:Nrows) {
            Dane[i, 1:2] <- c((sample(-range:range, 1) / (percent * range)) + vec[mod(i, k) + 1, 1], (sample(-range:range, 1) / (percent * range)) + vec[mod(i, k) + 1, 2])
            #Data[i, 1:2] <- 0 + vec[mod(i, k) + 1,]
        }
        for (i in 1:k * 5) {
            j <- sample(1:Nrows, 1)
            Dane[j, 1:2] <- c(sample(-range:range, 1), sample(-range:range, 1))

        }
        Dane[, 4:(3 + k)] = matrix(c((sample(0:1000, k * Nrows) / 1000)), ncol = k, nrow = Nrows)
        #Data[, 1:2] <- c(sample(-range:range, 2 * Nrows, replace = T));
        return(Dane)
    }


    FWeights <- function(x, y) {
        # przypisanie na podstawie min odleg³oœci do clustera 
        vec <- matrix(c(0), ncol = k, nrow = Nrows)

        for (i in 1:Nrows) {
            vec[i,] <- (CentEucDist(x[, 1:2], y)[i,]) # obliczenie odleg³oœci od Przypadkowych centroidów
        }

        vec <- vec / max(abs(vec));
        # unormowanie wag nale¿enia do clustera
        x[, 4:(3 + k)] <- (1 - vec);
        # przemianowanie z najmniejszej odleg³oœci na najwiêksze prawdopodobieñstwo nale¿enia
        #x[, 3] <- which.max(x[, 4:(3 + k)])
        return(x)
    }

    Fcentroid <- function(x) {
        odp <- matrix(0, ncol = 2, byrow = T, nrow = k)
        lx <- c(0)
        ly <- c(0)
        mxy <- c(0)
        for (j in 1:k) {
            for (i in 1:Nrows) {
                lx[i] <- x[i, (3 + j)] * x[i, 1]
                ly[i] <- x[i, (3 + j)] * x[i, 2]
                mxy[i] <- x[i, (3 + j)]
            }


            #c(sum(x[, 4:(k + 3)] * x[, 1]) / sum((x[, 4:(k + 3)])), sum(x[, 4:(k + 3)] * x[, 2]) / sum((x[, 4:(k + 3)])))
            #centroid <- c(sum(x[i, 4:(k + 3)] * x[i, 1]) / sum((x[i, 4:(k + 3)])), sum(x[i, 4:(k + 3)] * x[i, 2]) / sum((x[i, 4:(k + 3)])))

            odp[j,] <- c(sum(lx) / sum(mxy), sum(ly) / sum(mxy))
            #print(odp)
        }
        #odp <- matrix(centroid, ncol = 2, byrow = T, nrow = k)

        return(odp);
    }

}
k = 7
Ncolumns = k + 3
Nrows = 20*k
range = 200
percent = 0.025
m=2

Fdata <- PopulateFData()
Fdata
Fcenters <- Fcentroid(Fdata)
ColorPlot(Fdata, Fcenters)
#Kcenters = matrix(c(sample(-range:range, 2 * k)), ncol = 2, nrow = k);
#Fdata <- FWeights(Fdata, Kcenters)
#Fdata
for (i in 1:20) {
    Fdata <- FWeights(Fdata, Fcenters)
    Fcenters <- Fcentroid(Fdata)
    ColorPlot(Fdata, Fcenters)
    print(i)
}


#Data[, 1:2] <- c(sample(-range:range, 2 * Nrows, replace = T));
#Data[, 1:2] <- c(sample(-100:100, 2 * Nrows, replace = T)) / 10000;
Data <- PopulateDataKMeans();
Data
Data[, 3] = KMeansCluster(Data[, 1:2], Kcenters)
Plot(Data, Kcenters)
ColorPlot(Data, Kcenters)
Kcenters
StartKMeans(50, dane, Kcenters)

