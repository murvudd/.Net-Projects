# definicja funkcji
{

    EucDist <- function(x, y) { return(sqrt((x[1] - y[1]) ^ 2 + (x[2] - y[2]) ^ 2)) }

    CentDist <- function(x, y) {
        mat = matrix(0, nrow = length(x[, 1]), ncol = length(y[, 1]));
        for (i in 1:length(x[, 1])) {
            for (j in 1:length(y[, 1])) {
                mat[i, j] = EucDist(x[i,], y[j,])
            }
        }
        return(mat)
    }

    Cluster <- function(x, y) {
        v <- c(0);
        for (i in 1:length(x[, 1])) {
            v[i] <- which.min(CentDist(x, y)[i,])
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

    NewCentroid <- function(x, y) {
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



    Start <- function(x, dane, �rodki) {
        k = length(�rodki[, 1]);
        for (i in 1:x) {
            if (ProdOfVec(�rodki == NewCentroid(dane, �rodki)) == T) { print("Gotowe!"); break; }
            ColorPlot(dane, �rodki)
            �rodki <- NewCentroid(dane, �rodki)
            dane[, 3] = Cluster(dane[, 1:2], �rodki)
            print(i);
            #Sys.sleep(1)
        }
    }



}

Ncolumns = 3;
Nrows = 200;
range = 1000;
k = 7;
dane <- matrix(0, ncol = Ncolumns, nrow = Nrows)
dane[, 1:2] = c(sample(-range:range, (Ncolumns - 1) * Nrows, replace = T))
�rodki = matrix(c(sample(-range:range, 2 * k)), ncol = 2, nrow = k);
dane[, 3] = Cluster(dane[, 1:2], �rodki)
Plot(dane, �rodki)
ColorPlot(dane, �rodki)
�rodki
for (i in 1:50) { if (ProdOfVec(�rodki == NewCentroid(dane, �rodki)) == T) { print("Gotowe!"); break; }; ColorPlot(dane, �rodki); �rodki <- NewCentroid(dane, �rodki); dane[, 3] = Cluster(dane[, 1:2], �rodki); print(i); }
#Start(50,dane,�rodki)