# CSharpMathPuzzle
C#で解く数学パズルの数々

[Qiita](https://qiita.com/gushwell)に掲載した数学パズルのソースコードを公開しています。


### CenturyPuzzle : センチュリーパズル (西洋小町)

1～9までの数字を1回だけ使って帯分数をつくり、その値が100を表すようにするパズルです。

### CyclicNumberPuzzle : N倍すると巡回する自然数を求める

n倍して桁が巡回する自然数を求めてください。 nは、2 <= n <= 9 とします。この時の自然数を巡回数と言います。
例えば、1234の場合は、2倍した値が、2341, 3412, 4123 のいずれかになれば、巡回すると言えます。実際には、2倍した値は2468なので、巡回はしません。

### FourDigitReverseNumberPuzzle : 割り切れる4桁の逆転数

4桁の数値を順序を逆転させた数値（例えば、5432の場合は2345が逆転させた数値）で割ったときに、割り切れる4桁の数を求める。 (5432 / 2345 は割り切れないので求める答えではない） ただし、商が1のものや、割る数が4桁でないものは除外する。


### Komachi3ExpPuzzle : 小町数で3つの式の値を等しくする

「○○ − ○ = ○○ / ○ ＝ ○ ＋ ○ × ○ 」の○の部分に、1から9までの数がひとつずつ入るようにするパズル。


### KomachiFactorizationPuzzle : 素因数分解した結果が小町になる数を求める

ある整数 N を素因数分解したときに、因数が1-9をひとつずつ使っている Nを求めよ。それぞれの因数は、100未満とする。
ただし、求める N は、intで表現できる数とする。


### KomachiPuzzle : LINQで組み合わせを列挙して小町算を解く

1～9までの数字と＋、－、×、÷ の記号を使って、計算結果が100になる式を作る数学パズルです。
Roslynを使って動的に作成したC#のコードをコンパイルすることで、数式の計算を行っています。

### KomachiRingPuzzle : バックトラッキングで小町リングパズルを解く

以下のような５つの円に1-9までの数を入れ、どの円の中も合計すると同じ数になるように、数を埋めるというパズルです。左右の円は２つの合計、それ以外は3つの合計です。

![](https://github.com/gushwell/CSharpMathPuzzle/blob/master/Images/komachiRing.png)


### KomachiSquarePuzzle : 2乗した数値が小町になる数

3桁の数値とその数値を２乗した値の各数字が１から9までのすべての数字で構成されるような３桁の数値をすべて求める。


### KomachiUnitFraction : 小町数となる単位分数を求める

単位分数が、1/n となる、1-9までの数を１回ずつ使った分数を求めています。
ただし、n は、2から 9までの数です。
たとえば、6729/13458 は、1/2かつ1-9までの数を1回ずつ使っているので、求める答えのひとつです。

### MagicStarPuzzle : マジックスター(星陣)を解く

マジックスターは、星型に並べた12個の○に 1から12までの数字をひとつずつ入れていき、直線上の4個の数字の合計が、すべて 26 になるように、数字を配置するというものです。

### NParasiticNumberPuzzle : N-Parastic Number (N寄生数)を求める

N-Parastic Numberを求めてください。
N-Parastic Number: ある正の整数 A を N(1<=N<=9)倍した値と、Aを右へ一桁分ローテートシフトした値が等しい数。例えば、N=4 の時、102564 は `102564 * 4 = 410256`となり、N-Parastic Numberとなります。

### PalindromicSquarePuzzle : 二乗して回文となる非回文数を求める

二乗すると回文数となる数で、二乗する前の数が回文でない正の整数を求める。
回文数とは、21512 のように、逆から読んでも同じ数になる数字のことです。

### PennyFlippingProblemPuzzle : 覆銭問題（Penny Flipping Problem）

積み上げたコインを以下の手順でひっくり返すと何回目で初期状態に戻るかというもの。
1. n枚のコインを全部表にして積み上げる
2. 最初に、上の1枚を裏返す。次に上から2枚目をまとめてひっくり返す。次に3枚、4枚とひっくり返す。
3. n枚全体をひっくり返したら、また1枚に戻る。
この手順を繰り返す。

### RingNumberGcdPuzzle : リングナンバーの最大公約数

リング状に１から８の数字が並んでいます。
1から8までの任意の数字からはじめ、右回りあるいは左回りに数字を取り出し８ケタの数字を作ります。 
全部で16個の数字が得られますが、この最大公約数を求めてください。

### RisingEmirpNumbersPuzzle : エマープでかつ上昇数を求める

素数を逆転させた数もまた素数である自然数のことを 「エマープ(Emirp)」と言います。
1479のように、左から右へどんどん大きな数字になってゆく数を「上昇数」と呼びます。
このエマープかつ上昇数を求めています。

### SteinhausTrianglePuzzle: ステインハウスの三角形

以下の３つの条件を満たしたものをステインハウスの三角形と言う。

1. この三角形は以下のように０と１から成っている。
2. m行目はm-1行目の隣同士の数字の排他的論理和となっている。
3. 三角形内の 0 の数と1の数が同じである。

三角形の辺の長さ n を与えられた時、すべてのステインハウスの三角形を描くプログラムを書け。

### Triangle15Puzzle: Triangle15パズル

以下のような○を組み合わせた逆三角形に「横に並んだ２つの数の差(正数)をその下の○に入れる」という条件を満たして、1～ｎまでの数字を配置します。
例えば、3段の三角形の場合は、以下のように 1～6までの数を入れれば、条件を満たせます。

![](Images/Triangle15Puzzle.png)

では、5段の三角形の場合は、どのように配置すれば良いのか考えてください。

