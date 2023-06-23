: ISQRT-X1 ( n1 xo -- n1 x0 x1 )
  \ n1 : zero or positive signed integer
  \ x0 : estimate of square root
  \ x1 : new estimate of square root
  2DUP / ( n1 x0 [ n1/x0 ] )
  OVER ( n1 x0 [ n1/x0 ] x0 )
  + ( n1 x0 [ n1/x0 + x0 ] )
  2 / ( n1 x0 [ x1 = [n1/x0+x0]/2 ] ) ;  

: ISQRT ( n1 -- n2 )
  \ n1 : zero or positive signed integer
  \ n2 : largest integer <= SQRT(n1)
  ( n1 )
  DUP 0>= ( n1 flag ) \ negative error
  IF ( n1 >= 0 ) ( n1 )
    DUP 1 > ( n1 flag ) \ 0, 1 -> 0, 1
    IF ( n1 > 1 ) ( n1 )
      DUP 2 / ( n1 x0 ) \ x0 = n1/2
      BEGIN
	ISQRT-X1 ( n1 x0 x1) \ x1 = [n1/x0 + x0]/2
	2DUP > ( n1 x0 x1 flag )
      WHILE ( x0 > x1 ) ( n1 x0 x1 )
	NIP ( n1 [x0 = x1] )
      REPEAT
      DROP NIP ( x0 )
    THEN
  ELSE
    DROP -1 ( -1 error return )
  THEN ;
