: GCD ( n1 n2 -- n3 )
  \ n1 : non-zero signed integer
  \ n2 : non-zero signed integer
  \ n3 = positive greatest common divisor of n1 and n2
  ( n1 n2 )
  BEGIN ( n1 n2, or result 0 )
    ?DUP ( n1 n2 n2, or result 0 )
  WHILE ( n2 <> 0 ) ( n1 n2 )
    TUCK ( n2 n1 n2 )
    MOD ( n2 { n1 mod n2 } )
    \ Note: MOD naturally swaps n1 n2 when n1 < n2
  REPEAT ( result )
  ABS ( ABS{result} );

: LCM ( n1 n2 -- LCM{ n1 n2 } )
  \ n1 = non-zero signed integer
  \ n2 = non-zero signed integer
  \ n3 = positive least common multiple of non-zero integers n1 and n2
  ( n1 n2 )
  2DUP ( n1 n2 n1 n2 )
  GCD ( n1 n2 gcd{n1 n2} )
  */ ( { n1 * n2 / gcd{n1 n2} } ) ; \ scale uses double, returns single
