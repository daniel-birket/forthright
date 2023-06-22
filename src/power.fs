: ** ( n1 n2 -- n3 )
  \ n1 : signed integer
  \ n2 : zero or positive signed integer
  \ n3 = n1^n2
  ( n1 n2 )
  ABS ( n1 ABS{n2} ) \ force positive power
  OVER ( n1 n2 n1 )
  IF ( n1 <> 0 ) ( n1 n2 )
    DUP ( n1 n2 n2 )
    IF ( n2 <> 0 ) ( n1 n2 )
      DUP 1- ( n1 n2 {n2 - 1} )
      IF ( n2 > 1 ) ( n1 n2 )
	DUP 1 AND ( n1 n2 f )
	IF ( n1 is odd ) ( n1 n2 )
	  OVER SWAP ( n1 n1 n2 )
	  1- ( n1 n1 n2-1 )
	  RECURSE ( n1 n1^n2-1 )
	  * ( n1^n2 ) \ return
	ELSE ( n1 is even ) ( n1 n2 )
	  SWAP DUP ( n2 n1 n1 )
	  * ( n2 n1^2 )
	  SWAP ( n1^2 n2 )
	  2 / ( n1^2 n2/2 )
	  RECURSE ( n1^n2 ) \ return
	THEN
      ELSE ( n2 = 1 ) ( n1 n2 )
	DROP ( n1 ) \ return
      THEN
    ELSE ( n2 = 0 ) ( n1 n2 )
      2DROP 1 ( 1 ) \ return
    THEN
  ELSE ( n1 = 0 ) ( n1 n2 )
    2DROP 0 ( 0 ) \ return
  THEN ;
