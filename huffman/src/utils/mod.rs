use std::collections::HashMap;

use super::structures::{ Node };

pub fn frequency(s: &str) -> HashMap<char, i32> {
    let mut hash_map = HashMap::new();
    for ch in s.chars() {
        let counter = hash_map.entry(ch).or_insert(0);
        *counter += 1;
    }
    hash_map
}

pub fn new_box(n: Node) -> Box<Node> {
    Box::new(n)
}

pub fn assign_codes(p: &Box<Node>, 
                h: &mut HashMap<char, String>,
                s: String ) {

    if let Some(ch) = p.ch {
        h.insert(ch, s);
    } else {
        if let Some(ref l) = p.left {
            assign_codes(l, h, s.clone() + "0");
        }
        if let Some(ref r) = p.right {
            assign_codes(r, h, s.clone() + "1");
        }
    }
}

pub fn encode_string(s: &str, h: &HashMap<char, String>) -> String {
    let mut r = "".to_string();
    let mut t:Option<&String>;

    for ch in s.chars() {
        t = h.get(&ch);
        r.push_str(t.unwrap());
    }
    r
}

pub fn decode_string(s: &str, root: &Box<Node>) -> String {

    let mut retval = "".to_string();
    let mut nodeptr = root;

    for x in s.chars() {
        if x == '0' {
            if let Some(ref l) = nodeptr.left {
                nodeptr = l;
            }
        } else {
            if let Some(ref r) = nodeptr.right {
                nodeptr = r;
            }
        }
        if let Some(ch) = nodeptr.ch {
            retval.push(ch);
            nodeptr = root;
        }
    }
    retval
}
